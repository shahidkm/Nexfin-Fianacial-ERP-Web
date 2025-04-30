using System.ComponentModel.DataAnnotations;

namespace InventoryAndAccountingServices.Domain.Entities
{
    public class InventoryLedger
    {
        [Key]
        public int LedgerId { get; set; }

        public int CompanyId { get; set; }

        public string LedgerName { get; set; }

        public string? Alias { get; set; }

        public int GroupId { get; set; }

        public decimal? OpeningBalance { get; set; }

        public string? DrCr { get; set; }

        public decimal Balance { get; set; }  // ✅ Needed for voucher balance logic

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public InventoryGroup Group { get; set; }
        public BankLedgerDetails? BankDetails { get; set; }
        public GstLedgerDetails? GstDetails { get; set; }
        public BillByBillDetails? BillByBillDetails { get; set; }
    }
}
