using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;
namespace UserService.Infrastructure.Persistence.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
