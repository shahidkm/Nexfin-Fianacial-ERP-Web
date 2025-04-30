using PayrollMasters.Application.Interfaces;
using PayrollMasters.Domain.Entities;
using PayrollMasters.Infrastucture.Persistence.Data;

namespace PayrollMasters.Infrastucture.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        public async Task<string> CreateEmployeeGroup(EmployeeGroup employeeGroup)
        {
            var group = await _context.EmployeeGroups.AddAsync(employeeGroup);
            await _context.SaveChangesAsync();
            return ("Employee group created successfully");
        }

        public async Task<string> CreateEmployee(Employee employee)
        {
            var group = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return ("Employee created successfully");
        }

        public async Task<string> CreateEmployeePayHeadAssignment(EmployeePayHeadAssignment employeePayHeadAssignment)
        {
            var group = await _context.EmployeePayHeadAssignments.AddAsync(employeePayHeadAssignment);
            await _context.SaveChangesAsync();
            return ("Employee pay head asignment created successfully");
        }

    }
}
