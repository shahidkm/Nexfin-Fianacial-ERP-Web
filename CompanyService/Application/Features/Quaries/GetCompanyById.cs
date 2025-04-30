using CompanyService.Domain.Entities;
using MediatR;

namespace CompanyService.Application.Features.Quaries
{
    public class GetCompanyById : IRequest<Company>
    {
        public int CompanyId { get; set; }
        public string UserId { get; set; }
    }
}
