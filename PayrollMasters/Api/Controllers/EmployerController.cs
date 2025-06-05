using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollMasters.Application.Features.Commands;
using PayrollService.Application.Features.Commands;
using PayrollService.Application.Features.Queries;
using PayrollService.Contracts;

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
        public async Task<IActionResult> CreateEmployeeGroup(EmployeeGroupDto command, CancellationToken cancellationToken)
        {

            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }

            var companyId = Convert.ToInt32(companyIdObj);

            var Command = new EmployeeGroupCommand(
               CompanyId:companyId,
                GroupName:command.GroupName
               

                );
      
            var result = await _mediator.Send(Command, cancellationToken);
            return Ok(result);
        }


        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployee([FromForm] AddEmployeeDto command, CancellationToken cancellationToken)
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }

            var companyId = Convert.ToInt32(companyIdObj);

            var newCommand = new EmployeeCommand
            (
                CompanyId : companyId,
                Email : command.Email,
                Address : command.Address,
                BankAccountNumber : command.BankAccountNumber,
                BankName : command.BankName,
                FullName : command.FullName,
                BasicSalary : command.BasicSalary,
                IFSC : command.IFSC,
                Gender : command.Gender,
                GroupId : command.GroupId,
                DateOfBirth : command.DateOfBirth,
                Department : command.Department,
                Designation : command.Designation,
                Phone:command.Phone,
                Image:command.Image
            );

            var result = await _mediator.Send(newCommand, cancellationToken);
            return Ok(result);
        }



        //[HttpPost("assign-employee-pay-head")]
        //public async Task<IActionResult> AssignEmployeePayHead(EmployeePayHeadAssignmentCommand employeePayHeadAssignmentCommand, CancellationToken cancellationToken)
        //{


        //    var result = await _mediator.Send(employeePayHeadAssignmentCommand, cancellationToken);
        //    return Ok(result);
        //}
        [HttpPost("create-attendance-type")]
        public async Task<IActionResult> CreateAttendanceType(CreateAttendanceTypeCommand command, CancellationToken cancellationToken)
        {

            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPost("create-payhead")]
        public async Task<IActionResult> CreatePayHead(CreatePayHeadDto command, CancellationToken cancellationToken)
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }

            var companyId = Convert.ToInt32(companyIdObj);
            var Command = new CreatePayHeadCommand(
                Name: command.Name,
                Type:command.Type,
                CalculationType:command.CalculationType,
                FixedAmount:command.FixedAmount,
                Percentage:command.Percentage,
                AttendanceTypeId:command.AttendanceTypeId,
                CompanyId:companyId
                

                );


            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPost("assign-payhead")]
        public async Task<IActionResult> AssignPayHead(AssignPayHeadCommand command, CancellationToken cancellationToken) => Ok(await _mediator.Send(command, cancellationToken));

        [HttpPost("record-attendance")]
        public async Task<IActionResult> RecordAttendance(RecordAttendanceCommand command, CancellationToken cancellationToken) => Ok(await _mediator.Send(command, cancellationToken));

        [HttpPost("create-payroll-voucher")]
        public async Task<IActionResult> CreatePayrollVoucher(CreatePayrollVoucherCommand command, CancellationToken cancellationToken) => Ok(await _mediator.Send(command, cancellationToken));

        [HttpGet("monthly-payroll-summary")]
        public async Task<IActionResult> GetMonthlyPayrollSummary([FromQuery] int month, [FromQuery] int year)
        {
            var result = await _mediator.Send(new GetMonthlyPayrollSummaryQuery(month, year));
            return Ok(result);
        }

        [HttpGet("get-employee-salary")]
        public async Task<IActionResult> GetMonthlyEmployeePayrollSummary(int employeeId)
        {
            var result = await _mediator.Send(new GetMonthlyEmployeePayrollSummaryQuery(employeeId));
            return Ok(result);
        }
        [HttpGet("get-daily-salary")]
        public async Task<IActionResult> GetDailySalary(int employeeId)
        {
            var result = await _mediator.Send(new GetMonthlyEmployeePayrollSummaryQuery(employeeId));
            return Ok(result);
        }
        [HttpGet("get-employee-groups")]
        public async Task<IActionResult> GetEmployeeGroups(int id)
        {
            var result = await _mediator.Send(new GetEmployeeGroups(id));
            return Ok(result);
        }
        [HttpGet("employe-profile")]

        public async Task<IActionResult> GetEmployeeProfile(int id)
        {
            var result =await _mediator.Send(new GetEmployeeProfileQuary(id));
            return Ok(result);
        }

        [HttpGet("get-employee-attendense")]
        public async Task<IActionResult>GetEmployeeAttendense(int id, DateTime fromDate, DateTime toDat)
        {
            var result=await _mediator.Send(new GetEmployeeAttendance(id, fromDate, toDat));
            return Ok(result);
        }

        [HttpGet("get-employee")]
        public async Task<IActionResult>GetEmployee(int Id)
        {
            var details=await _mediator.Send(new GetEmployeeDetailsQuary(Id));
            return Ok(details);
        }

    }
}
