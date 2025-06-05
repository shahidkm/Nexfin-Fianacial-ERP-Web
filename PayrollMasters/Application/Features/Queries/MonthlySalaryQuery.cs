using MediatR;
using PayrollService.Contracts;

namespace PayrollService.Application.Features.Queries
{
    public record GetMonthlyEmployeePayrollSummaryQuery(int employeeId) : IRequest<MonthlyPayrollSummaryDto>;
    public record GetMonthlyPayrollSummaryQuery(int Month, int Year) : IRequest<List<MonthlyPayrollSummaryDto>>;
}
