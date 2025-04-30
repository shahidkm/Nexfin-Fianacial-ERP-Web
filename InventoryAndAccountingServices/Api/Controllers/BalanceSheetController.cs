using InventoryAndAccountingServices.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAndAccountingServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceSheetController : ControllerBase
    {
        private readonly BalanceSheetRepository _balanceSheetRepository;

        public BalanceSheetController(BalanceSheetRepository balanceSheetRepository)
        {
            _balanceSheetRepository = balanceSheetRepository;
        }

        [HttpGet("balance-sheet")]
        public async Task<ActionResult> RetriveBalanceSheet( DateTime? date)
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }

            var companyId = Convert.ToInt32(companyIdObj);

            var response = await _balanceSheetRepository.GetBalanceSheetAsync(companyId, date ?? DateTime.Today);

            return Ok(response);
        }
    }
}
