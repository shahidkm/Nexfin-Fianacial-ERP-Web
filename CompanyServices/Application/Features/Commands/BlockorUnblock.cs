using MediatR;
namespace CompanyServices.Application.Features.Commands
{
    public class BlockorUnblockCommand :IRequest<string>
    {
        public int CompanyId { get; set; }
   
    }
}
