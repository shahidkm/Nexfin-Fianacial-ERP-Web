using PayrollMasters.Domain.Entities;

namespace PayrollService.Application.Interfaces
{
    public interface IAttendenceRepository
    {
        Task<string> CraeteAttendenceType(AttendanceType attendanceType);
    }
}
