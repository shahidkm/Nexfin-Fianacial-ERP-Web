
using MediatR;
namespace CompanyServices.Application.Features.Commands
{
    public class DeleteCompanyCommand :IRequest<string>
    {
        public int CompanyId { get; set; }
       
    }
}
