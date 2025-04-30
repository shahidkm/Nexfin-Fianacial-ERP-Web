using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Features.Commands;
using UserService.Application.Features.Quaries;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Persistence.Repositories;
using UserService.Infrastructure.Services;

namespace UserService.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;


        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]

        public async Task<ActionResult> RegisterUser([FromForm] RegisterUserCommand registerUser, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(registerUser, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]

        public async Task<ActionResult> LoginUser([FromForm] LoginCommand loginCommand)
        {
            var verify = await _mediator.Send(loginCommand);
            return Ok(verify);
        }

        [HttpPost("select-company")]
        public async Task<IActionResult> SelectCompany([FromForm] GetSelectCompany request)
        {
            //if (!HttpContext.Items.TryGetValue("UserId", out var userIdObj) || userIdObj == null)
            //{
            //    return Unauthorized("User not authenticated.");
            //}

            //var userId = userIdObj.ToString();

            //// Use 'with' to create a new record with updated UserId
            

            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
};
