using AccountingAndInventoryMastersService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountingAndInventoryMastersService.Infrastructure.Persistence.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }

        public DbSet<InventoryGroup> InventoryGroups { get; set; }
        public DbSet<InventoryLedger> InventoryLedgers { get; set; }

    }
}
 