using PayrollMasters.Domain.Entities;
using PayrollService.Application.Features.Commands;
using PayrollService.Contracts;

namespace PayrollService.Application.Interfaces
{
    public interface IAttendenceRepository
    {
        Task<string> CreateAttendanceType(AttendanceType attendanceType);
        Task<string> CreatePayHead(PayHead payHead);
        Task<string> AssignPayHead(EmployeePayHeadAssignment assignment);
        Task<string> RecordAttendance(EmployeeAttendance attendance);
        Task<string> GeneratePayrollVoucherAsync(CreatePayrollVoucherCommand command);
        Task<List<MonthlyPayrollSummaryDto>> GetMonthlyPayrollSummary(int month, int year);
        Task<MonthlyPayrollSummaryDto> GetEmployeeCurrentMonthSalary(int employeeId);
        Task<List<DailySalaryDetailDto>> GetDailySalaryDetails(int employeeId);
        Task<List<EmployeeAttendanceDto>> GetAttendanceBetweenDates(int employeeId, DateTime fromDate, DateTime toDate);
    }
   
}
