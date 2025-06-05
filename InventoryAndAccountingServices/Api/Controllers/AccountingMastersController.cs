using InventoryAndAccountingServices.Application.Features.Commands;
using InventoryAndAccountingServices.Application.Features.Queries;
using InventoryAndAccountingServices.Application.Features.Queries.Accounting_Masters;
using InventoryAndAccountingServices.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAndAccountingServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountMastersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAccountingMastersRepositories _repository;

        public AccountMastersController(IMediator mediator,IAccountingMastersRepositories accountingMastersRepositories)
        {
            _mediator = mediator;
            _repository = accountingMastersRepositories;
        }


        [HttpPost("create-inventory-group")]

        public async Task<ActionResult> CreateInventoryGroup([FromForm] InventoryGroupCommand command)
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);
            var group =  new InventoryGroupCommand(
       CompanyId: companyId,
       GroupName: command.GroupName,
       Alias: command.Alias,
       ParentGroupId: command.ParentGroupId,
       SubLedger:command.SubLedger,
       AllocateInPurchase:command.AllocateInPurchase,
       NetBalance:command.NetBalance

   );

            var Response = await _mediator.Send(group);
            return Ok(Response);
        }


        [HttpPost("create-inventory-ledger")]

        public async Task<ActionResult> CreateInventoryLedger(InventoryLedgerCommand command)
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);

            var group = new InventoryLedgerCommand(
                LedgerId:command.LedgerId,
      CompanyId: companyId,
      LedgerName:command.LedgerName,
      Alias: command.Alias,
      GroupId:command.GroupId,
      OpeningBalance:command.OpeningBalance,
      DrCr:command.DrCr,
      BankDetails:command.BankDetails,
      GstDetails:command.GstDetails,
      BillByBillDetails:command.BillByBillDetails
  );

            var Response = await _mediator.Send(group);
            return Ok(Response);
        }

        [HttpGet("get-group")]

        public async Task<ActionResult> RetriveInventoryGroup()
        {
            try
            {
                if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
                {
                    return Unauthorized("Company not found.");
                }
                var companyId = Convert.ToInt32(companyIdObj);
                var query = new GetInventoryGroupQuery
                {
                    CompanyId = companyId
                };
               var response= await _mediator.Send(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("seed-primary-groups")]

        public async Task<ActionResult> SeedPrimaryGroup()
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);

            var response = await _repository.CreateDefaultInventoryGroupsAsync(companyId);
            return Ok(response);

        }
        [HttpGet("get-ledger")]
        public async Task<ActionResult> RetriveInventoryLedger()
        {
            try
            {
                if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
                {
                    return Unauthorized("Company not found.");
                }
                var companyId = Convert.ToInt32(companyIdObj);
                var query = new GetInventoryLedgerQuery
                {
                    CompanyId = companyId
                };
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


