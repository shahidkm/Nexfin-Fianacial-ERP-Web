using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CompanyServices.Infrastructure.Persistanse.Data;
using CompanyServices.Application.Features.Commands;
using CompanyServices.Application.Features.Quaries;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace CompanyServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;

        public CompanyController(IMediator mediator, AppDbContext appDbContext)
        {
            _mediator = mediator;
            _context = appDbContext;
        }

        [HttpPost("create-company")]
        public async Task<ActionResult> CreateCompany([FromForm] CreateCompanyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                // Check if UserId exists in HttpContext
                if (!HttpContext.Items.TryGetValue("UserId", out var userIdObj) || userIdObj == null)
                {
                    return Unauthorized("User not authenticated.");
                }

                command.UserId = userIdObj.ToString();
                var response = await _mediator.Send(command, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating company: {ex.Message}");
            }
        }

        [HttpGet("get-company-by-user")]
        public async Task<ActionResult> GetCompanyByUser()
        {
            if (!HttpContext.Items.TryGetValue("UserId", out var userIdObj) || userIdObj == null)
            {
                return Unauthorized("User not authenticated.");
            }

            var userId = userIdObj.ToString();
            var request = new GetCompanyByUserQuary(userId);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

       

        [HttpGet("get-selected-company")]
        public async Task<ActionResult> GetSelectedCompany()
        {
            try
            {
                // Check if the CompanyId is available in HttpContext.Items
                if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
                {
                    return Unauthorized("Company not found.");
                }
                var companyId = Convert.ToInt32(companyIdObj);

                var request = new GetSelectedCompany(companyId);
               
                    var response = await _mediator.Send(request);
                    // You can use the companyId for whatever you need
                    return Ok(response);  // Returning the companyId in response
                  
                
           
               
        
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching selected company: {ex.Message}");
            }
        }

        [HttpPost("add-company-role")]
        public async Task<ActionResult> CreateCompanyRole([FromForm] CreateCompanyRoles createCompanyRoles)
        {
            try
            {
                // Ensure UserId is in HttpContext
                if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
                {
                    return Unauthorized("Company id missing.");
                }
                createCompanyRoles.CompanyId = Convert.ToInt32(companyIdObj);

                var response = await _mediator.Send(createCompanyRoles);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding company role: {ex.Message}");
            }
        }

        [HttpGet("all-companies")]

        public async Task<ActionResult> RetriveAllCompanies()
        {
            try
            {
                if (!HttpContext.Items.TryGetValue("UserId", out var userIdObj) || userIdObj == null)
                {
                    return Unauthorized("User not authenticated.");
                }
                  var userId = userIdObj.ToString();
                var query = new GetCompanyQuery
                {
                    UserId = userId
                };
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpGet("blocked-companies")]

        public async Task<ActionResult> RetriveBlockedCompanies()
        {
            try
            {
                if (!HttpContext.Items.TryGetValue("UserId", out var userIdObj) || userIdObj == null)
                {
                    return Unauthorized("User not authenticated.");
                }
                var userId = userIdObj.ToString();
                var query = new GetBlockedCompaniesQuery
                {
                    UserId = userId
                };
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("active-companies")]
        public async Task<ActionResult> RetriveActiveCompanies()
        {
            try
            {
                if (!HttpContext.Items.TryGetValue("UserId", out var userIdObj) || userIdObj == null)
                {
                    return Unauthorized("User not authenticated.");
                }
                var userId = userIdObj.ToString();
                var query = new GetActiveCompaniesQuery
                {
                    UserId = userId
                };
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpGet("company-based-role")]
        public async Task<ActionResult> RetriveCompanyBasedRole()
        {
            try
            {
                if (!HttpContext.Items.TryGetValue("Email", out var emailObj) || emailObj == null)
                {
                    return Unauthorized("User not authenticated.");
                }
                var email = emailObj.ToString();
                var query = new     GetCompanyBasedRoleQuery
                {
                    Email=email
                };
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("select-company")]

        public async Task<ActionResult> SelectCompany(GetSelectCompany getSelectedCompany)
        {
            try
            {
                if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
                {
                    return Unauthorized("Company not found.");
                }
               
                 
                var response = await _mediator.Send(getSelectedCompany);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("edit-company")]

        public async Task<ActionResult> EditCompany(EditCompanyCommand command)
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var response = await _mediator.Send(command);
            return Ok(response);

        }

        [HttpDelete("delete-company")]

        public async Task<ActionResult> DeleteCompany(DeleteCompanyCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("block-unblock")]

        public async Task<ActionResult> BlockorUnblock(BlockorUnblockCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        [HttpGet("user-role")]

        public async Task<ActionResult> UserRoles()
        {
            if (!HttpContext.Items.TryGetValue("Email", out var EmailObj) || EmailObj == null)
            {
                return Unauthorized("Email not found.");
            }
            var  email = EmailObj.ToString();

            var query = new GetUserRolesQuery
            {
                Email = email
            };
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
