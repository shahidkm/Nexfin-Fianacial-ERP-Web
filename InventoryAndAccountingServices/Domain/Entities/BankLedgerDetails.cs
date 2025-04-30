using System.ComponentModel.DataAnnotations;

namespace InventoryAndAccountingServices.Domain.Entities
{
    public class BankLedgerDetails
    {
        [Key]
        public int LedgerId { get; set; }

        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSC { get; set; }
        public string BranchName { get; set; }

        public InventoryLedger Ledger { get; set; }
    }

}
