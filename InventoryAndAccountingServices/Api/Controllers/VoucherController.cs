using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAndAccountingServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherRepository _voucherRepository;


        public VoucherController(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }




        [HttpPost("create-voucher")]
        public async Task<ActionResult> CreateVoucher( CreateVoucherDto createVoucherDto)
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);
            createVoucherDto.CompanyId = companyId;
            var response = await _voucherRepository.CreateVoucherAsync(createVoucherDto);
            return Ok(response);
        } 

    }
}
