using CompanyService.Domain.Entities;
using MediatR;

namespace CompanyService.Application.Features.Queries
{
    public record GetCompanyByUser(string UserId) : IRequest<List<Company>>;
}
