using AutoMapper;
using MediatR;
using PayrollMasters.Domain.Entities;
using PayrollService.Application.Interfaces;

namespace PayrollService.Application.Features.Commands
{
    public class AssignPayHeadHandler : IRequestHandler<AssignPayHeadCommand, string>
    {
        private readonly IAttendenceRepository _repository;
        private readonly IMapper _mapper;

        public AssignPayHeadHandler(IAttendenceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(AssignPayHeadCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EmployeePayHeadAssignment>(request);
            return await _repository.AssignPayHead(entity);
        }
    }
}
