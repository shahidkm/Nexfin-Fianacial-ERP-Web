using MediatR;
using PayrollService.Contracts;

namespace PayrollService.Application.Features.Queries
{
    public record GetEmployeeDetailsQuary(int employeeId) : IRequest<GetEmployeeDetailsDto>;
}
