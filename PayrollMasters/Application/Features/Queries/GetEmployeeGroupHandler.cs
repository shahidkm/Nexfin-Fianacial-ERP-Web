using MediatR;
using PayrollMasters.Application.Interfaces;
using PayrollMasters.Domain.Entities;
using PayrollService.Application.Interfaces;
using PayrollService.Contracts;

namespace PayrollService.Application.Features.Queries
{
    public class GetEmployeeGroupHandler : IRequestHandler<GetEmployeeGroups, List<EmployeeGroup>>
    {
        private readonly IEmployeeRepository _repository;

        public GetEmployeeGroupHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeGroup>> Handle(GetEmployeeGroups request, CancellationToken cancellationToken)
        {
            return await _repository.GetEmployeeGroups(request.id);
        }
    }
}
