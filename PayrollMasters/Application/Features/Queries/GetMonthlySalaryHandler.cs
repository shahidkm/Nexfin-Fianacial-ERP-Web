using MediatR;
using PayrollService.Application.Interfaces;
using PayrollService.Contracts;

namespace PayrollService.Application.Features.Queries
{
    public class GetMonthlyPayrollSummaryHandler : IRequestHandler<GetMonthlyPayrollSummaryQuery, List<MonthlyPayrollSummaryDto>>
    {
        private readonly IAttendenceRepository _repository;

        public GetMonthlyPayrollSummaryHandler(IAttendenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MonthlyPayrollSummaryDto>> Handle(GetMonthlyPayrollSummaryQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMonthlyPayrollSummary(request.Month, request.Year);
        }
    }
}
