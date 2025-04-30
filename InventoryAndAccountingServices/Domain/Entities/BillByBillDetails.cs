using System.ComponentModel.DataAnnotations;

namespace InventoryAndAccountingServices.Domain.Entities
{
    public class BillByBillDetails
    {
        [Key]
        public int LedgerId { get; set; }

        public bool IsBillByBillEnabled { get; set; }
        public int CreditPeriod { get; set; } // in days
        public string? ReferenceType { get; set; } // New Ref, Against Ref, etc.

        public InventoryLedger Ledger { get; set; }
    }

}
