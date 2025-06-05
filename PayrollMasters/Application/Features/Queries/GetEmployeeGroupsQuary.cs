using MediatR;
using PayrollMasters.Domain.Entities;
using PayrollService.Contracts;

namespace PayrollService.Application.Features.Queries
{
    public record GetEmployeeGroups(int id) : IRequest<List<EmployeeGroup>>;
}
