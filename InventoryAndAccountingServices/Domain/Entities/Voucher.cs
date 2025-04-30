using InventoryAndAccountingServices.Domain.Enums;

namespace InventoryAndAccountingServices.Domain.Entities
{
    public class Voucher
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string VoucherNumber { get; set; } = string.Empty;
        public VoucherType Type { get; set; }
        public DateTime Date { get; set; }
        public string Narration { get; set; } = string.Empty;

        // Navigation
        public ICollection<VoucherEntry> Entries { get; set; } = new List<VoucherEntry>();
        public ICollection<VoucherItem>? Items { get; set; } // Optional for stock-based vouchers
        public DispatchDetails? DispatchDetails { get; set; }
    }
}
