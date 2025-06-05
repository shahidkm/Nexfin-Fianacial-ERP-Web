using MediatR;
using PayrollMasters.Application.Interfaces;
using PayrollService.Application.Interfaces;
using PayrollService.Contracts;

namespace PayrollService.Application.Features.Queries
{
    public class GetEmployeeDetailsQuaryHandler : IRequestHandler<GetEmployeeDetailsQuary, GetEmployeeDetailsDto>
    {
        private readonly IEmployeeRepository _repository;

        public GetEmployeeDetailsQuaryHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetEmployeeDetailsDto> Handle(GetEmployeeDetailsQuary request, CancellationToken cancellationToken)
        {
            return await _repository.GetEmployeeDetails(request.employeeId);
        }
    }
}
