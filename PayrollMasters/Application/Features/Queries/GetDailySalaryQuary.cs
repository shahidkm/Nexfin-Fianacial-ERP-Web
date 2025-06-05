using MediatR;
using PayrollService.Contracts;

namespace PayrollService.Application.Features.Queries
{
    public record GetDailySalaryQuary(int employeeId) : IRequest<List<DailySalaryDetailDto>>;
}
