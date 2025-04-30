using Microsoft.EntityFrameworkCore;
using PayrollMasters.Domain.Entities;

namespace PayrollMasters.Infrastucture.Persistence.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeGroup> EmployeeGroups { get; set; }

        public DbSet<AttendanceType> AttendanceTypes { get; set; }


        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

        public DbSet<EmployeePayHeadAssignment> EmployeePayHeadAssignments { get; set; }

        public DbSet<PayHead> PayHeads { get; set; }
        public DbSet<PayrollVoucher> PayrollVouchers { get; set; }
        public DbSet<PayrollVoucherBreakup> PayrollVoucherBreakups { get; set; }
        public DbSet<PayrollVoucherEntry> PayrollVoucherEntrys { get; set; }


    }
}
