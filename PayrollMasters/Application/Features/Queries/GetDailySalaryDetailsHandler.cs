using MediatR;
using PayrollService.Application.Interfaces;
using PayrollService.Contracts;

namespace PayrollService.Application.Features.Queries
{
    public class GetDailySalaryDetailsHandler : IRequestHandler<GetDailySalaryQuary, List<DailySalaryDetailDto>>
    {
        private readonly IAttendenceRepository _repository;

        public GetDailySalaryDetailsHandler(IAttendenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DailySalaryDetailDto>> Handle(GetDailySalaryQuary request, CancellationToken cancellationToken)
        {
            return await _repository.GetDailySalaryDetails(request.employeeId);
        }
    }
}
