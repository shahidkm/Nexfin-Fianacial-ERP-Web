using MediatR;
using PayrollMasters.Application.Interfaces;
using PayrollMasters.Domain.Entities;

namespace PayrollMasters.Application.Features.Commands
{
    public class EmployeeGroupHandler :IRequestHandler<EmployeeGroupCommand,string>
    {

        private readonly IEmployeeRepository _repository;

        public EmployeeGroupHandler(IEmployeeRepository employeeRepository)
        {
            _repository = employeeRepository;
        }


        public Task<string> Handle(EmployeeGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new EmployeeGroup
            {
                GroupName = request.GroupName,
                CompanyId = request.CompanyId
            };
            var result = _repository.CreateEmployeeGroup(group);
            return result;
        }
    }
}
