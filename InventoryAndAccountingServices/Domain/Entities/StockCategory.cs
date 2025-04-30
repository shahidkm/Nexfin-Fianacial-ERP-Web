using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InventoryAndAccountingServices.Domain.Entities
{
    public class StockCategory
    {
        public int StockCategoryId { get; set; }
        public int CompanyId { get; set; }
        public string CategoryName { get; set; }
        public string? Alias { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

      
        //public ICollection<StockItem> StockItems { get; set; }
    }
}
