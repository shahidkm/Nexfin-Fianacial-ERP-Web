using AccountingAndInventoryMastersService.Applictaion.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingAndInventoryMastersService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountMastersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountMastersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("create-inventory-group")]

        public async Task<ActionResult>CreateInventoryGroup(InventoryGroupCommand command)
        {
            var Response = await _mediator.Send(command);
            return Ok(Response);
        }


        [HttpPost("create-inventory-ledger")]

        public async Task<ActionResult> CreateInventoryLedger(InventoryLedgerCommand command)
        {
            var Response = await _mediator.Send(command);
            return Ok(Response);
        }

    }
}
