using MediatR;
using PayrollService.Application.Interfaces;

namespace PayrollService.Application.Features.Commands
{
    public class CreatePayrollVoucherHandler : IRequestHandler<CreatePayrollVoucherCommand, string>
    {
        private readonly IAttendenceRepository _service;

        public CreatePayrollVoucherHandler(IAttendenceRepository service)
        {
            _service = service;
        }

        public async Task<string> Handle(CreatePayrollVoucherCommand request, CancellationToken cancellationToken)
        {
            return await _service.GeneratePayrollVoucherAsync(request);
        }
    }
}
