using CompanyServices.Contracts;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetCompanyBasedRoleQuery :IRequest<List<GetCompanyBasedRoleDto>>
    {
        public string? Email { get; set; }
    
    }
}
