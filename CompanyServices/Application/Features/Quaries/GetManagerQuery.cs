using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public record GetManagerQuary(int CompanyId) : IRequest<List<CompanyRole>>;
}
