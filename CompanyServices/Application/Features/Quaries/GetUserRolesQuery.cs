using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetUserRolesQuery: IRequest<List<CompanyRole>>
    {
        public string? Email { get; set; }
    }
}
