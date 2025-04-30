using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InventoryAndAccountingServices.Domain.Entities
{
    public class UnitOfMeasure
    {
        [Key]
        public int UnitId { get; set; }
        public int CompanyId { get; set; }
        public string UnitName { get; set; }
        public string Symbol { get; set; }  
        public DateTime CreatedDate { get; set; } = DateTime.Now;

     
        //public ICollection<StockItem> StockItems { get; set; }
    }
}
