using PayrollMasters.Domain.Entities;

namespace PayrollMasters.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<string> CreateEmployeeGroup(EmployeeGroup employeeGroup);
        Task<string> CreateEmployee(Employee employee);
        Task<string> CreateEmployeePayHeadAssignment(EmployeePayHeadAssignment employeePayHeadAssignment);
    }
}
