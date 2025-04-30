using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public record GetSelectCompany(int CompanyId) : IRequest<string>;

}
