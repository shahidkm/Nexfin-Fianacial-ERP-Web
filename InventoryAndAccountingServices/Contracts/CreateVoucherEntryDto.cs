using InventoryAndAccountingServices.Domain.Enums;

namespace InventoryAndAccountingServices.Contracts
{
    public class CreateVoucherEntryDto
    {
        public int LedgerId { get; set; }
        public EntryType EntryType { get; set; }
        public decimal Amount { get; set; }
    }
}
