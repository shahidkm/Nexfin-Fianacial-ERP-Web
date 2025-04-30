using MediatR;

namespace CompanyService.Application.Features.Commands
{
    public class CreateCompanyRoles : IRequest<string>
    {
        public int CompanyId { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }
}
