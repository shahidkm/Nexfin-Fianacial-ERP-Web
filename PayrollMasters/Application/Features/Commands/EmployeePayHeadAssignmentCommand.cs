using MediatR;

namespace PayrollService.Application.Features.Commands
{
    public record EmployeePayHeadAssignmentCommand(int EmployeeId, int PayHeadId, decimal Amount, bool? IsPercentage) : IRequest<string>;
}
