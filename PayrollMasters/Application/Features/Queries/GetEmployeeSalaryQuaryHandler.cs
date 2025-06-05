using MediatR;
using PayrollService.Application.Interfaces;
using PayrollService.Contracts;

namespace PayrollService.Application.Features.Queries
{
    public class GetMonthlyEmployeePayrollSummaryHandler : IRequestHandler<GetMonthlyEmployeePayrollSummaryQuery, MonthlyPayrollSummaryDto>
    {
        private readonly IAttendenceRepository _repository;

        public GetMonthlyEmployeePayrollSummaryHandler(IAttendenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<MonthlyPayrollSummaryDto> Handle(GetMonthlyEmployeePayrollSummaryQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetEmployeeCurrentMonthSalary(request.employeeId);
        }
    }
}
