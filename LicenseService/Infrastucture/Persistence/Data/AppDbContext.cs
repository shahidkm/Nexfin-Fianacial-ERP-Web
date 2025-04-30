using System.Collections.Generic;
using LicenseService.Domain.Entites;
using Microsoft.EntityFrameworkCore;
namespace LicenseService.Infrastucture.Persistence.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<LicenseModel> Licenses { get; set; } 

    }
}
