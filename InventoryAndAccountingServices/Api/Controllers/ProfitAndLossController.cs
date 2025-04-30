using InventoryAndAccountingServices.Contracts;
using InventoryAndAccountingServices.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAndAccountingServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfitAndLossController : ControllerBase
    {
        private readonly ProfitAndLossRepository _profitAndLossRepository;

        public ProfitAndLossController(ProfitAndLossRepository profitAndLossRepository)
        {
            _profitAndLossRepository = profitAndLossRepository;
        }


        [HttpGet("profit-and-loss")]
        public async Task<ActionResult<ProfitAndLossDto>> GetProfitAndLoss(
        
          [FromQuery] DateTime fromDate,
          [FromQuery] DateTime toDate)
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }

            var companyId = Convert.ToInt32(companyIdObj);

            if (fromDate > toDate)
                return BadRequest("FromDate must be earlier than ToDate.");

            var result = await _profitAndLossRepository.GetProfitAndLossAsync(companyId, fromDate, toDate);

            return Ok(result);
        }
    }
}
