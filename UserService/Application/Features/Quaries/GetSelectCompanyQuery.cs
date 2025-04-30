using MediatR;

namespace UserService.Application.Features.Quaries
{
    public record GetSelectCompany(Guid ? UserId,int CompanyId) : IRequest<string>;
}
