using MediatR;

namespace PayrollMasters.Application.Features.Commands
{
   public record EmployeeGroupCommand(int CompanyId, string GroupName) :IRequest<string>;
}
