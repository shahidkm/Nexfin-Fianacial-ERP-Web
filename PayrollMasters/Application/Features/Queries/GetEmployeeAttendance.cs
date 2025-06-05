using MediatR;
using PayrollService.Contracts;

namespace PayrollService.Application.Features.Queries
{
    public record GetEmployeeAttendance(int employeeId, DateTime fromDate, DateTime toDate) : IRequest<List<EmployeeAttendanceDto>>;
}
