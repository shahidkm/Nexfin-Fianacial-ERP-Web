using InventoryAndAccountingServices.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace InventoryAndAccountingServices.Domain.Entities
{
    public class InventoryGroup
    {
        [Key]
        public int GroupId { get; set; }
        public int? CompanyId { get; set; }
        public string? GroupName { get; set; }
        public string? Alias { get; set; }
        public int? ParentGroupId { get; set; }
        public string? SubLedger { get; set; }
        public string? NetBalance { get; set; }
        public string? AllocateInPurchase { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public InventoryGroup? ParentGroup { get; set; }
        public ICollection<InventoryGroup> ChildGroups { get; set; } = new List<InventoryGroup>();

        
        public GroupNature? Nature { get; set; }
    }
}
