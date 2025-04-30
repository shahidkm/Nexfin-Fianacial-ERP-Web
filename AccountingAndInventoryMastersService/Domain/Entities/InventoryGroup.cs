using System.ComponentModel.DataAnnotations;

namespace AccountingAndInventoryMastersService.Domain.Entities
{
    public class InventoryGroup
    {
        [Key]
        public int GroupId { get; set; }
        public string ?CompanyId { get; set; }
        public string? GroupName { get; set; }
        public string? Alias { get; set; }
        public int? ParentGroupId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public InventoryGroup? ParentGroup { get; set; }
    }
}
