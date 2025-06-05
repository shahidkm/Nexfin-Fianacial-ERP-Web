using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollMasters.Application.Interfaces;
using PayrollMasters.Domain.Entities;
using PayrollMasters.Infrastucture.Persistence.Data;
using PayrollService.Contracts;
using PayrollService.Contracts.YourAppNamespace.Dtos;

namespace PayrollMasters.Infrastucture.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

       
        public EmployeeRepository(AppDbContext appDbContext,IMediator mediator )
        {
            _context = appDbContext;
            _mediator = mediator;
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

        public async Task<List<EmployeeGroup>> GetEmployeeGroups(int id)
        {
            var group = await _context.EmployeeGroups.Where(g => g.CompanyId == id).ToListAsync();

            return group;
        }

        public async Task<EmployeeDto> GetEmployeeProfile(int employeeId)
        {
            var employee= _context.Employees.FirstOrDefault(e=>e.EmployeeId== employeeId);
            var groupName = _context.EmployeeGroups.FirstOrDefault(g => g.GroupId == employee.GroupId);
            var employeeProfile = new EmployeeDto
            {
                FullName=employee.FullName,
                DateOfBirth=employee.DateOfBirth,
                BasicSalary=employee.BasicSalary,
                Gender=employee.Gender,
                BankAccountNumber=employee.BankAccountNumber,
                BankName=employee.BankName,
                Email=employee.Email,
                IFSC=employee.IFSC,
                Address=employee.Address,
                DateOfJoining=employee.DateOfJoining,
                Department=employee.Department,
                Designation=employee.Designation,
                GroupName=groupName.GroupName,
                Phone=employee.Phone,
               

            };
             return employeeProfile;
        }
        public async  Task<GetEmployeeDetailsDto> GetEmployeeDetails(int id)
        {
            var employee =await _context.Employees.FirstOrDefaultAsync(e=>e.EmployeeId == id);
            var details = new GetEmployeeDetailsDto
            {
                EmployeeId = employee.EmployeeId,
                FullName = employee.FullName,
                Designation = employee.Designation,
                Image = employee.Image
            };
            return details;
        }
    }
}
