using MediatR;
using Microsoft.AspNetCore.Mvc;
using LicenseService.Application.Features.Commands;
using Serilog;
using LicenseService.Infrastucture.Services;

namespace LicenseService.API.Controllers
{
    [Route("api/license")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly IMediator _mediator;
      
        public LicenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-license")]
        public async Task<IActionResult> CreateLicense([FromForm] LicenseCommand command, CancellationToken cancellationToken)
        {
            try {
                if (!HttpContext.Items.ContainsKey("UserId"))
                {
                    return Unauthorized("User not authenticated.");
                }
                command.UserId = HttpContext.Items["UserId"].ToString();
                Console.WriteLine(command.UserId);
                var result = await _mediator.Send(command, cancellationToken);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }


        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromForm] SendOtpCommand sendOtpCommand)
        {
            await _mediator.Send(sendOtpCommand);
            return Ok("OTP sent");
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromForm] VerifyOtpCommand verifyOtpCommand)
        {
            var valid = await _mediator.Send(verifyOtpCommand);
            return valid ? Ok("Verified") : BadRequest("Invalid OTP");
        }

    }
}
