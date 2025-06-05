using MediatR;
using PayrollMasters.Domain.Entities;
using PayrollService.Contracts.YourAppNamespace.Dtos;

namespace PayrollService.Application.Features.Queries
{
    public record GetEmployeeProfileQuary(int id) : IRequest<EmployeeDto>;
}
