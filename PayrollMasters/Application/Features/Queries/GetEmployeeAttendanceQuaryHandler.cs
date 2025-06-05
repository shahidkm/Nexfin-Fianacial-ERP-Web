using MediatR;
using PayrollService.Application.Interfaces;
using PayrollService.Contracts;

namespace PayrollService.Application.Features.Queries
{
    public class GetEmployeeAttendanceHandler : IRequestHandler<GetEmployeeAttendance, List<EmployeeAttendanceDto>>
    {
        private readonly IAttendenceRepository _repository;

        public GetEmployeeAttendanceHandler(IAttendenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeAttendanceDto>> Handle(GetEmployeeAttendance request, CancellationToken cancellationToken)
        {
            return await _repository.GetAttendanceBetweenDates(request.employeeId,request.fromDate,request.toDate);
        }
    }
}
