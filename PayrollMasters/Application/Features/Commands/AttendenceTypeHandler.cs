using AutoMapper;
using MediatR;
using PayrollMasters.Domain.Entities;
using PayrollService.Application.Interfaces;

namespace PayrollService.Application.Features.Commands
{
    public class CreateAttendanceTypeHandler : IRequestHandler<CreateAttendanceTypeCommand, string>
    {
        private readonly IAttendenceRepository _repository;
        private readonly IMapper _mapper;

        public CreateAttendanceTypeHandler(IAttendenceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateAttendanceTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<AttendanceType>(request);
            return await _repository.CreateAttendanceType(entity);

        }




    }

}