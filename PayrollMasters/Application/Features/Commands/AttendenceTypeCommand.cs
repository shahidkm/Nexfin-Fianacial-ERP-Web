using MediatR;

namespace PayrollService.Application.Features.Commands
{
    public record CreateAttendanceTypeCommand(string AttendenceName, string Type, string Unit) : IRequest<string>;
    public record CreatePayHeadCommand(string Name, string Type, string CalculationType, decimal? FixedAmount, decimal? Percentage, int? AttendanceTypeId,int CompanyId) : IRequest<string>;
    public record AssignPayHeadCommand(int EmployeeId, int PayHeadId, decimal Amount, bool? IsPercentage) : IRequest<string>;
    public record RecordAttendanceCommand(int EmployeeId, int AttendanceTypeId, DateTime Date) : IRequest<string>;
    public record CreatePayrollVoucherCommand(string VoucherNumber, DateTime Date) : IRequest<string>;

}
