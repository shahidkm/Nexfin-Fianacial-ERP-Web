using PayrollMasters.Domain.Entities;
using PayrollMasters.Infrastucture.Persistence.Data;

namespace PayrollService.Infrastucture.Persistence.Repositories
{
    public class AttendenceRepository
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
    }
}
