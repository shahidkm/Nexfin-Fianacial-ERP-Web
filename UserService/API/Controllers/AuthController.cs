using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Features.Commands;
using UserService.Application.Features.Quaries;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
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

        public async Task<ActionResult> RegisterUser([FromForm] RegisterUserCommand user, CancellationToken cancellationToken)
        {
            try
            {
                if (user.FullName == null)
                {
                    return BadRequest("Full name is required");
                }
                if (user.Email == null)
                {
                  
                    return BadRequest("Email is required");
                }
                if (user.Password == null)
                {
                    
                    return BadRequest("Password is required");
                }
                if (user.Password.Length < 6)
                {
                    return BadRequest("Password must contain six characteres");
                }
                var response = await _mediator.Send(user, cancellationToken);
                if (response == "Already an user registered with this email.")
                {
                    return BadRequest("Already an user registered with this email.");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromForm] LoginCommand loginCommand)
        {
            var result = await _mediator.Send(loginCommand);

            return result.Message switch
            {
                "User not found." => NotFound(result.Message),
                "Email not matches." or "Incorrect password." => Unauthorized(result.Message),
                _ => Ok(result)
            };
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
