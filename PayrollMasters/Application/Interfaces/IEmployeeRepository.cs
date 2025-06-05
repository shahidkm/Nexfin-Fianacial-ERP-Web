using PayrollMasters.Domain.Entities;
using PayrollService.Contracts;

namespace PayrollMasters.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<string> CreateEmployeeGroup(EmployeeGroup employeeGroup);
        Task<string> CreateEmployee(Employee employee);
        Task<string> CreateEmployeePayHeadAssignment(EmployeePayHeadAssignment employeePayHeadAssignment);
        Task<List<EmployeeGroup>> GetEmployeeGroups(int id);
        Task<GetEmployeeDetailsDto>GetEmployeeDetails(int id);
    }
}
