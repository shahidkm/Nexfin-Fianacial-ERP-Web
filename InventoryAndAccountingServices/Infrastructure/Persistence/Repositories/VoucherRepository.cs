using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Contracts;
using InventoryAndAccountingServices.Domain.Entities;
using InventoryAndAccountingServices.Domain.Enums;
using InventoryAndAccountingServices.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

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
           
            var voucher = new Voucher
            {CompanyId = dto.CompanyId,
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

          
            _context.Vouchers.Add(voucher);

           
            foreach (var entry in dto.Entries)
            {
                var ledger = await _context.InventoryLedgers.FindAsync(entry.LedgerId);
                if (ledger == null)
                    throw new Exception("Ledger not found");

                if (entry.EntryType == EntryType.Debit)
                    ledger.Balance += entry.Amount;
                else if (entry.EntryType == EntryType.Credit)
                    ledger.Balance -= entry.Amount;

                _context.InventoryLedgers.Update(ledger);
            }

            if (dto.Type == VoucherType.Sales || dto.Type == VoucherType.Purchase)
            {
                foreach (var item in dto.Items ?? new List<CreateVoucherItemDto>())
                {
                    var stockItem = await _context.StockItems.FindAsync(item.ItemId);
                    if (stockItem == null)
                        throw new Exception("Stock item not found");

                 
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


        public async Task<List<Voucher>> GetAllVouchersByCompanyIdAsync(int companyId)
        {
            return await _context.Vouchers
                .Where(v => v.CompanyId == companyId) 
                .ToListAsync();
        }

        public async Task<List<Voucher>> GetDifferentVouchersByCompanyIdAsync( int companyId, VoucherType voucherType)
        {
            return await _context.Vouchers
                .Where(v => v.CompanyId == companyId && v.Type == voucherType)
                .ToListAsync();
        }
        public async Task<List<Voucher>> DayBook(int companyId)
        {
            DateTime today = DateTime.Today; // same as DateTime.Now.Date

            return await _context.Vouchers
                .Include(v => v.Entries) // Eager load voucher entries
                .Where(v => v.CompanyId == companyId && v.Date.Date == today)
                .ToListAsync();
        }

    }
}
