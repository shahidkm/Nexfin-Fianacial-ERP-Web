using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public record GetAccountantQuary(int CompanyId) : IRequest<List<CompanyRole>>;
}