using InventoryAndAccountingServices.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Serialization;

namespace InventoryAndAccountingServices.Domain.Entities
{

    public class VoucherEntry
    {
        public int Id { get; set; }
        public int VoucherId { get; set; }
        [JsonIgnore] 
        public Voucher Voucher { get; set; }

        public int LedgerId { get; set; }
        public InventoryLedger Ledger { get; set; }

        public decimal Amount { get; set; }
        public EntryType EntryType { get; set; } // Debit or Credit
    }
}
