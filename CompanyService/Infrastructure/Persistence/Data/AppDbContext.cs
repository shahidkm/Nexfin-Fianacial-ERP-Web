using CompanyService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyService.Infrastructure.Persistence.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyRole> CompanyRoles { get; set; }
    }
}
