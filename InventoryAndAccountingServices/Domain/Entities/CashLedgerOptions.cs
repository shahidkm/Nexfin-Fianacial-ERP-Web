using System.ComponentModel.DataAnnotations;

namespace InventoryAndAccountingServices.Domain.Entities
{
    public class CashLedgerOptions
    {
        [Key]
        public int LedgerId { get; set; }

        public bool AllowOverdraft { get; set; }

        public InventoryLedger Ledger { get; set; }
    }

}
