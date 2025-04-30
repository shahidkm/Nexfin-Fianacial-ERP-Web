using CompanyServices.Domain.Entities;
using MediatR;

namespace CompanyServices.Application.Features.Quaries
{
    public class GetCompanyByIdQuery : IRequest<bool>
    {
        public int CompanyId { get; set; }
        public string? UserId { get; set; }
    }
}
