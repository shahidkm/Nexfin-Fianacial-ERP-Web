using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InventoryAndAccountingServices.Domain.Entities
{
    public class StockGroup
    {
        [Key]
        public int StockGroupId { get; set; }
        public int CompanyId { get; set; }
        public string GroupName { get; set; }
        public string? Alias { get; set; }
        public int? ParentGroupId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        //public Company Company { get; set; }
        public StockGroup? ParentGroup { get; set; }
        //public ICollection<StockGroup> SubGroups { get; set; }
        //public ICollection<StockItem> StockItems { get; set; }
    }
}
