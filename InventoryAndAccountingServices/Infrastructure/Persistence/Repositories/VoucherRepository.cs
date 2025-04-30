using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Contracts;
using InventoryAndAccountingServices.Domain.Entities;
using InventoryAndAccountingServices.Domain.Enums;
using InventoryAndAccountingServices.Infrastructure.Persistence.Data;

namespace InventoryAndAccountingServices.Infrastructure.Persistence.Repositories
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly AppDbContext _context;

        public VoucherRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<string> CreateVoucherAsync(CreateVoucherDto dto)
        {
            // Step 1: Create voucher
            var voucher = new Voucher
            {
                VoucherNumber = dto.VoucherNumber,
                Type = dto.Type,
                Date = dto.Date,
                Narration = dto.Narration,
                Entries = dto.Entries.Select(e => new VoucherEntry
                {
                    LedgerId = e.LedgerId,
                    EntryType = e.EntryType,
                    Amount = e.Amount
                }).ToList(),
                Items = dto.Items?.Select(i => new VoucherItem
                {
                    ItemId = i.ItemId,
                    Quantity = i.Quantity,
                    Rate = i.Rate,
                    GSTTaxDetail = i.GST != null ? new GSTTaxDetail
                    {
                        CGSTPercent = i.GST.CGSTPercent,
                        SGSTPercent = i.GST.SGSTPercent,
                        IGSTPercent = i.GST.IGSTPercent
                    } : null
                }).ToList()
            };

            // Step 2: Add Dispatch Details
            if (dto.DispatchDetails != null)
            {
                voucher.DispatchDetails = new DispatchDetails
                {
                    DeliveryNoteNumber = dto.DispatchDetails.DeliveryNoteNumber,
                    DispatchDate = dto.DispatchDetails.DispatchDate,
                    DispatchedThrough = dto.DispatchDetails.DispatchedThrough,
                    Destination = dto.DispatchDetails.Destination,
                    LRNumber = dto.DispatchDetails.LRNumber,
                    VehicleNumber = dto.DispatchDetails.VehicleNumber,
                    FreightCharges = dto.DispatchDetails.FreightCharges
                };
            }

            // Step 3: Add Voucher to DB
            _context.Vouchers.Add(voucher);

            // Step 4: Update Ledger Balances
            foreach (var entry in dto.Entries)
            {
                var ledger = await _context.InventoryLedgers.FindAsync(entry.LedgerId);
                if (ledger == null)
                    throw new Exception("Ledger not found");

                // Apply balance update based on enum
                if (entry.EntryType == EntryType.Debit)
                    ledger.Balance += entry.Amount;
                else if (entry.EntryType == EntryType.Credit)
                    ledger.Balance -= entry.Amount;

                _context.InventoryLedgers.Update(ledger);
            }

            // Step 5: Update Stock Quantities (Only for Sales and Purchase Vouchers)
            if (dto.Type == VoucherType.Sales || dto.Type == VoucherType.Purchase)
            {
                foreach (var item in dto.Items ?? new List<CreateVoucherItemDto>())
                {
                    var stockItem = await _context.StockItems.FindAsync(item.ItemId);
                    if (stockItem == null)
                        throw new Exception("Stock item not found");

                    // Purchase: Increase stock, Sales: Decrease stock
                    if (dto.Type == VoucherType.Purchase)
                        stockItem.Quantity += item.Quantity;
                    else if (dto.Type == VoucherType.Sales)
                        stockItem.Quantity -= item.Quantity;

                    _context.StockItems.Update(stockItem);
                }
            }

            await _context.SaveChangesAsync();
            return ("Voucher Created Successfully");
        }
    }
}
