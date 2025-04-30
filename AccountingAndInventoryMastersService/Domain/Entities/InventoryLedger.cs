using System.ComponentModel.DataAnnotations;

namespace AccountingAndInventoryMastersService.Domain.Entities
{
    public class InventoryLedger
    {
        [Key]
        public int LedgerId { get; set; }
        public int CompanyId { get; set; }
        public string LedgerName { get; set; }
        public string? Alias { get; set; }
        public int GroupId { get; set; }
        public int? OpeningBalance { get; set; }
        public string? DrCr { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public InventoryGroup Group { get; set; }
    }
}
