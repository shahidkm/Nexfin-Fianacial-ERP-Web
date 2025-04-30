using System.ComponentModel.DataAnnotations;

namespace InventoryAndAccountingServices.Domain.Entities
{
    public class GstLedgerDetails
    {
        [Key]
        public int LedgerId { get; set; }

        public string GstType { get; set; } // CGST, SGST, IGST
        public decimal GstRate { get; set; }
        public string HsnSacCode { get; set; }

        public InventoryLedger Ledger { get; set; }
    }

}
