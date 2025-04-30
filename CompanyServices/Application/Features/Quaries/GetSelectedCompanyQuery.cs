using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public record GetSelectedCompany(int CompanyId) : IRequest<Company>;

}
