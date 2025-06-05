using AutoMapper;
using MediatR;
using PayrollMasters.Application.Interfaces;
using PayrollMasters.Domain.Entities;
using PayrollService.Application.Interfaces;

namespace PayrollService.Application.Features.Commands
{
    public class CreatePayHeadHandler : IRequestHandler<CreatePayHeadCommand, string>
    {
        private readonly IAttendenceRepository _repository;
        private readonly IMapper _mapper;

        public CreatePayHeadHandler(IAttendenceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreatePayHeadCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PayHead>(request);
            return await _repository.CreatePayHead(entity);

        }
    }
}