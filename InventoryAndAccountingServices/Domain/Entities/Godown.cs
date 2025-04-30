using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InventoryAndAccountingServices.Domain.Entities
{
    public class Godown
    {
        [Key]
        public int GodownId { get; set; }
        public int CompanyId { get; set; }
        public string GodownName { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        //public Company Company { get; set; }
        //public ICollection<StockTransaction> StockTransactions { get; set; }
    }
}
