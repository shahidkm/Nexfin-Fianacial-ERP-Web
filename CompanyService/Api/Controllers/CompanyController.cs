using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CompanyService.Application.Features.Commands;
using CompanyService.Application.Features.Queries;

using CompanyService.Application.Features.Quaries;
using CompanyService.Domain.Entities;
using CompanyService.Infrastructure.Persistence.Data;
namespace CompanyService.Api.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;

        public CompanyController(IMediator mediator,AppDbContext appDbContext)
        {
            _mediator = mediator;
            _context = appDbContext;
        }

        [HttpPost("create-company")]

        public async Task<ActionResult> CreateCompany([FromForm] CompanyCommand command, CancellationToken cancellationToken)
        {
            try {
                //if (!HttpContext.Items.ContainsKey("UserId"))
                //{
                //    return Unauthorized("User not authenticated.");
                //}
                //command.UserId = HttpContext.Items["UserId"].ToString();
                var Response = await _mediator.Send(command, cancellationToken);
                return Ok(Response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

}
        



        [HttpPost("create-compaaanyi")]

        public async Task<ActionResult> CreateCompanys(Company company)
        {
            try
            {
                //if (!HttpContext.Items.ContainsKey("UserId"))
                //{
                //    return Unauthorized("User not authenticated.");
                //}
                //command.UserId = HttpContext.Items["UserId"].ToString();
                var Response = await _context.Companies.AddAsync(company);
                return Ok("dsfsdfsdfs");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get-company-by-user")]

        public async Task<ActionResult> GetCompanyByUser()
        {
            if (!HttpContext.Items.ContainsKey("UserId"))
            {
                return Unauthorized("User not authenticated.");
            }
            var UserId = HttpContext.Items["UserId"].ToString();
            var request = new GetCompanyByUser(UserId);
          
            var Response = await _mediator.Send(request);
            return Ok(Response);
        }


        [HttpGet("select-company")]

        public async Task<ActionResult> SelectCompany([FromQuery] GetCompanyById getCompanyById)
        {
            try {
                if (!HttpContext.Items.ContainsKey("UserId"))
                {
                    return Unauthorized("User not authenticated.");
                }
                var UserId = HttpContext.Items["UserId"].ToString();
                HttpContext.Items["CompanyId"] = getCompanyById.CompanyId.ToString();
                var company = new GetCompanyById
                {
                    CompanyId = getCompanyById.CompanyId,
                    UserId = UserId
                };

                var Response = await _mediator.Send(getCompanyById);
                return Ok(Response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }


        [HttpPost("add-company-role")]

        public async Task<ActionResult> CreateCompanyRole(CreateCompanyRoles createCompanyRoles)
        {
            try
            {
                if (!HttpContext.Items.ContainsKey("UserId"))
                {
                    return Unauthorized("User not authenticated.");
                }
                var Response = await _mediator.Send(createCompanyRoles);
                return Ok(Response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }


}
