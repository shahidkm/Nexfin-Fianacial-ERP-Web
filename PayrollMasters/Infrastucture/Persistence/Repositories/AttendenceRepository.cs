using Microsoft.EntityFrameworkCore;
using PayrollMasters.Domain.Entities;
using PayrollMasters.Infrastucture.Persistence.Data;
using PayrollService.Application.Features.Commands;
using PayrollService.Application.Interfaces;
using PayrollService.Contracts;

namespace PayrollService.Infrastucture.Persistence.Repositories
{
    public class AttendenceRepository :IAttendenceRepository
    {
        private readonly AppDbContext _context;
        public AttendenceRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<string> CreateAttendenceType(AttendanceType attendanceType)
        {
            var group = await _context.AttendanceTypes.AddAsync(attendanceType);
            await _context.SaveChangesAsync();
            return ("Attendence type created");

        }
        public async Task<string> CreateAttendanceType(AttendanceType attendanceType)
        {
            try
            {
                await _context.AttendanceTypes.AddAsync(attendanceType);
                await _context.SaveChangesAsync();
                return "Attendance type created successfully";
            }
            catch (Exception ex)
            {
                return $"Error creating attendance type: {ex.Message}";
            }
        }

        public async Task<string> CreatePayHead(PayHead payHead)
        {
            try
            {
                await _context.PayHeads.AddAsync(payHead);
                await _context.SaveChangesAsync();
                return "PayHead created successfully";
            }
            catch (Exception ex)
            {
                return $"Error creating payhead: {ex.Message}";
            }
        }

        public async Task<string> AssignPayHead(EmployeePayHeadAssignment assignment)
        {
            try
            {
                await _context.EmployeePayHeadAssignments.AddAsync(assignment);
                await _context.SaveChangesAsync();
                return "PayHead assigned to employee successfully";
            }
            catch (Exception ex)
            {
                return $"Error assigning payhead: {ex.Message}";
            }
        }

        public async Task<string> RecordAttendance(EmployeeAttendance attendance)
        {
            try
            {
                await _context.EmployeeAttendances.AddAsync(attendance);
                await _context.SaveChangesAsync();
                return "Attendance recorded successfully";
            }
            catch (Exception ex)
            {
                return $"Error recording attendance: {ex.Message}";
            }
        }

        public async Task<string> GeneratePayrollVoucherAsync(CreatePayrollVoucherCommand command)
        {
            try
            {
                var voucher = new PayrollVoucher
                {
                    VoucherNumber = command.VoucherNumber,
                    Date = command.Date,
                    Entries = new List<PayrollVoucherEntry>()
                };

                await _context.PayrollVouchers.AddAsync(voucher);
                await _context.SaveChangesAsync();

                return "Payroll voucher created successfully";
            }
            catch (Exception ex)
            {
                return $"Error creating payroll voucher: {ex.Message}";
            }
        }
        public async Task<List<MonthlyPayrollSummaryDto>> GetMonthlyPayrollSummary(int month, int year)
        {
            try
            {
                var employees = await _context.Employees.Include(e => e.Group).ToListAsync();

                var result = new List<MonthlyPayrollSummaryDto>();

                foreach (var employee in employees)
                {
                    var attendances = await _context.EmployeeAttendances
                        .Where(a => a.EmployeeId == employee.EmployeeId && a.Date.Month == month && a.Date.Year == year)
                        .ToListAsync();

                    int presentDays = attendances.Count(a => a.AttendanceType.Type == "Present");
                    int absentDays = attendances.Count(a => a.AttendanceType.Type == "Absent");

                    var payHeads = await _context.EmployeePayHeadAssignments
                        .Where(x => x.EmployeeId == employee.EmployeeId)
                        .Include(x => x.PayHead)
                        .ToListAsync();

                    decimal earnings = 0;
                    decimal deductions = 0;
                    var payHeadDetails = new List<PayHeadDetailDto>();

                    foreach (var ph in payHeads)
                    {
                        decimal amount = ph.IsPercentage == true
                            ? (ph.PayHead.CalculationType == "Attendance" ? ph.Amount * presentDays : ph.Amount)
                            : ph.Amount;

         
                        payHeadDetails.Add(new PayHeadDetailDto
                        {
                            PayHeadName = ph.PayHead.Name,
                            PayHeadType = ph.PayHead.Type,
                            Amount = amount
                        });

                        if (ph.PayHead.Type == "Earning") earnings += amount;
                        else if (ph.PayHead.Type == "Deduction") deductions += amount;
                    }

                    result.Add(new MonthlyPayrollSummaryDto
                    {
                        EmployeeId = employee.EmployeeId,
                        EmployeeName = employee.FullName,
                        GroupName = employee.Group?.GroupName ?? "",
                        TotalEarnings = earnings,
                        TotalDeductions = deductions,
                        NetPay = earnings - deductions,
                        PresentDays = presentDays,
                        AbsentDays = absentDays,
                        PayHeadDetails = payHeadDetails  
                    });
                }

                return result;
            }
            catch (Exception ex)
            {
               
                throw new Exception("Failed to fetch payroll summary.", ex);
            }
        }

        public async Task<MonthlyPayrollSummaryDto> GetEmployeeCurrentMonthSalary(int employeeId)
        {
            try
            {
                var currentDate = DateTime.Now;
                int month = currentDate.Month;
                int year = currentDate.Year;

                var employee = await _context.Employees
                    .Include(e => e.Group)
                    .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

                if (employee == null)
                    throw new Exception("Employee not found.");

                var attendances = await _context.EmployeeAttendances
                    .Where(a => a.EmployeeId == employeeId && a.Date.Month == month && a.Date.Year == year)
                    .Include(a => a.AttendanceType)
                    .ToListAsync();

                int presentDays = attendances.Count(a => a.AttendanceType.Type == "Present");
                int absentDays = attendances.Count(a => a.AttendanceType.Type == "Absent");

                var payHeads = await _context.EmployeePayHeadAssignments
                    .Where(x => x.EmployeeId == employeeId)
                    .Include(x => x.PayHead)
                    .ToListAsync();

                decimal earnings = 0;
                decimal deductions = 0;
                var payHeadDetails = new List<PayHeadDetailDto>();

                foreach (var ph in payHeads)
                {
                    decimal amount = ph.IsPercentage == true
                        ? (ph.PayHead.CalculationType == "Attendance" ? ph.Amount * presentDays : ph.Amount)
                        : ph.Amount;

                    payHeadDetails.Add(new PayHeadDetailDto
                    {
                        PayHeadName = ph.PayHead.Name,
                        PayHeadType = ph.PayHead.Type,
                        Amount = amount
                    });

                    if (ph.PayHead.Type == "Earning") earnings += amount;
                    else if (ph.PayHead.Type == "Deduction") deductions += amount;
                }

                return new MonthlyPayrollSummaryDto
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeName = employee.FullName,
                    GroupName = employee.Group?.GroupName ?? "",
                    TotalEarnings = earnings,
                    TotalDeductions = deductions,
                    NetPay = earnings - deductions,
                    PresentDays = presentDays,
                    AbsentDays = absentDays,
                    PayHeadDetails = payHeadDetails
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch employee salary for current month.", ex);
            }
        }
        public async Task<List<DailySalaryDetailDto>> GetDailySalaryDetails(int employeeId)
        {
            try
            {
                var now = DateTime.Now;
                int month = now.Month;
                int year = now.Year;

                var employee = await _context.Employees
                    .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

                if (employee == null)
                    throw new Exception("Employee not found.");

                var attendances = await _context.EmployeeAttendances
                    .Where(a => a.EmployeeId == employeeId && a.Date.Month == month && a.Date.Year == year)
                    .Include(a => a.AttendanceType)
                    .ToListAsync();

                var payHeads = await _context.EmployeePayHeadAssignments
                    .Where(x => x.EmployeeId == employeeId)
                    .Include(x => x.PayHead)
                    .ToListAsync();

                var dailyDetails = new List<DailySalaryDetailDto>();

                foreach (var attendance in attendances.OrderBy(a => a.Date))
                {
                    decimal dailyEarnings = 0;
                    decimal dailyDeductions = 0;

                    foreach (var ph in payHeads)
                    {
                        bool isPresent = attendance.AttendanceType.Type == "Present";

                        decimal amount = 0;

                        if (ph.PayHead.CalculationType == "Attendance")
                        {
                            amount = isPresent ? ph.Amount : 0;
                        }
                        else
                        {
                            //amount = ph.IsPercentage ? ph.Amount : ph.Amount / DateTime.DaysInMonth(year, month);
                        }

                        if (ph.PayHead.Type == "Earning") dailyEarnings += amount;
                        else if (ph.PayHead.Type == "Deduction") dailyDeductions += amount;
                    }

                    dailyDetails.Add(new DailySalaryDetailDto
                    {
                        Date = attendance.Date,
                        AttendanceType = attendance.AttendanceType.Type,
                        Earnings = dailyEarnings,
                        Deductions = dailyDeductions,
                        NetPay = dailyEarnings - dailyDeductions
                    });
                }

                return dailyDetails;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch daily salary details.", ex);
            }
        }
        public async Task<List<EmployeeAttendanceDto>> GetAttendanceBetweenDates(int employeeId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var employee = await _context.Employees
                    .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

                if (employee == null)
                    throw new Exception("Employee not found.");

                var attendances = await _context.EmployeeAttendances
                    .Where(a => a.EmployeeId == employeeId && a.Date >= fromDate && a.Date <= toDate)
                    .Include(a => a.AttendanceType)
                    .OrderBy(a => a.Date)
                    .ToListAsync();

                var attendanceList = attendances.Select(a => new EmployeeAttendanceDto
                {
                    Date = a.Date,
                    AttendanceType = a.AttendanceType.Type
                }).ToList();

                return attendanceList;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch attendance records for the given period.", ex);
            }
        }

    }
}
