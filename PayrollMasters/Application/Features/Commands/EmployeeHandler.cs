using AutoMapper;
using MediatR;
using PayrollMasters.Application.Features.Commands;
using PayrollMasters.Application.Interfaces;
using PayrollMasters.Domain.Entities;

namespace PayrollService.Application.Features.Commands
{
    public class EmployeeHandler : IRequestHandler<EmployeeCommand, string>
    {

        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeHandler(IEmployeeRepository employeeRepository,IMapper mapper)
        {
            _repository = employeeRepository;
            _mapper = mapper;
        }


        public Task<string> Handle(EmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);
            var result = _repository.CreateEmployee(employee);
            return result;
        }
    }
}
