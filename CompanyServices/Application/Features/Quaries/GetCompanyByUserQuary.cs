using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public record GetCompanyByUserQuary(string UserId) : IRequest<List<Company>>;
}
