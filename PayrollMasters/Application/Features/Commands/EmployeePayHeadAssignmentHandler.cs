using AutoMapper;
using MediatR;
using PayrollMasters.Application.Interfaces;
using PayrollMasters.Domain.Entities;

namespace PayrollService.Application.Features.Commands
{
    public class EmployeePayHeadAssignmentHandler : IRequestHandler<EmployeePayHeadAssignmentCommand, string>
    {

        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeePayHeadAssignmentHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _repository = employeeRepository;
            _mapper = mapper;
        }


        public Task<string> Handle(EmployeePayHeadAssignmentCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<EmployeePayHeadAssignment>(request);
            var result = _repository.CreateEmployeePayHeadAssignment(employee);
            return result;
        }
    }
}
