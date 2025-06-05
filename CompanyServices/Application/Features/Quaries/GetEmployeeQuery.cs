using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public record GetEmployeeQuary(int CompanyId) : IRequest<List<CompanyRole>>;
}
