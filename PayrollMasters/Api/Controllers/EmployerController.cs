using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollMasters.Application.Features.Commands;
using PayrollService.Application.Features.Commands;

namespace PayrollMasters.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {

        private readonly IMediator _mediator;
        public EmployerController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost("create-employee-group")]
        public async Task<IActionResult> CreateEmployeeGroup(EmployeeGroupCommand command, CancellationToken cancellationToken)
        {
          
      
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }


        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployee(EmployeeCommand command, CancellationToken cancellationToken)
        {


            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }


        [HttpPost("assign-employee-pay-head")]
        public async Task<IActionResult> AssignEmployeePayHead(EmployeePayHeadAssignmentCommand employeePayHeadAssignmentCommand, CancellationToken cancellationToken)
        {


            var result = await _mediator.Send(employeePayHeadAssignmentCommand, cancellationToken);
            return Ok(result);
        }
    }
}
