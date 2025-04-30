using InventoryAndAccountingServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryAndAccountingServices.Infrastructure.Persistence.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }

        public DbSet<InventoryGroup> InventoryGroups { get; set; }
        public DbSet<InventoryLedger> InventoryLedgers { get; set; }
        public DbSet<StockGroup> StockGroups { get; set; }
        public DbSet<StockCategory> StockCategories { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<Godown> Godowns { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherEntry> VoucherEntries { get; set; }
        public DbSet<VoucherItem> VoucherItems { get; set; }
        public DbSet<GstLedgerDetails> GstLedgerDetails { get; set; }
        public DbSet<BankLedgerDetails> BankLedgerDetails { get; set; }
        public DbSet<BillByBillDetails> BillByBillDetails { get; set; }
        public DbSet<GSTTaxDetail> GSTTaxDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StockItem>()
               .Property(s => s.OpeningQty)
               .HasPrecision(18, 2);

            modelBuilder.Entity<StockItem>()
                .Property(s => s.OpeningRate)
                .HasPrecision(18, 2);

            modelBuilder.Entity<DispatchDetails>()
    .Property(d => d.FreightCharges)
    .HasPrecision(18, 2);

            modelBuilder.Entity<GSTTaxDetail>(e =>
            {
                e.Property(g => g.CGSTPercent).HasPrecision(5, 2);
                e.Property(g => g.SGSTPercent).HasPrecision(5, 2);
                e.Property(g => g.IGSTPercent).HasPrecision(5, 2);
            });

            modelBuilder.Entity<VoucherEntry>()
                .Property(v => v.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<VoucherItem>(e =>
            {
                e.Property(i => i.Quantity).HasPrecision(18, 2);
                e.Property(i => i.Rate).HasPrecision(18, 2);
            });


            modelBuilder.Entity<InventoryLedger>()
    .Property(e => e.Balance)
    .HasPrecision(18, 4); // adjust as needed

            modelBuilder.Entity<InventoryLedger>()
                .Property(e => e.OpeningBalance)
                .HasPrecision(18, 4);

            modelBuilder.Entity<StockItem>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 4);


        }
    }
}