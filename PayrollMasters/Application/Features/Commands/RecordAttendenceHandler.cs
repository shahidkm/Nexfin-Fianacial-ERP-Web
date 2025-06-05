using AutoMapper;
using MediatR;
using PayrollMasters.Domain.Entities;
using PayrollService.Application.Interfaces;

namespace PayrollService.Application.Features.Commands
{
    public class RecordAttendanceHandler : IRequestHandler<RecordAttendanceCommand, string>
    {
        private readonly IAttendenceRepository _repository;
        private readonly IMapper _mapper;

        public RecordAttendanceHandler(IAttendenceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(RecordAttendanceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EmployeeAttendance>(request);
            return await _repository.RecordAttendance(entity);
        }
    }
}
