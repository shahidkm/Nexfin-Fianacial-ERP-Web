using InventoryAndAccountingServices.Application.Features.Commands.Inventory_Masters;
using InventoryAndAccountingServices.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAndAccountingServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IInventoryMastersRepository _inventoryRepository;

        public InventoryController(IMediator mediator, IInventoryMastersRepository inventoryMastersRepository)
        {
            _mediator = mediator;
            _inventoryRepository = inventoryMastersRepository;
        }
        [HttpPost("create-stock-group")]

        public async Task<ActionResult> CreateStockGroup([FromForm] StockGroupCommand stockGroupCommand)
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);
            var stockGroup = new StockGroupCommand(
                CompanyId: companyId,
                GroupName: stockGroupCommand.GroupName,
                Alias: stockGroupCommand.Alias,
                ParentGroupId: stockGroupCommand.ParentGroupId

                );
            var Response = await _mediator.Send(stockGroup);
            return Ok(Response);
        }

        [HttpPost("create-stock-category")]


        public async Task<ActionResult> CreateStockCategory([FromForm] StockCategoryCommand stockCategoryCommand)
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);

            var category = new StockCategoryCommand(
                CompanyId: companyId,
                CategoryName: stockCategoryCommand.CategoryName,
                Alias: stockCategoryCommand.Alias
                );
            var Response = await _mediator.Send(category);
            return Ok(Response);
        }

        [HttpPost("create-units")]

        public async Task<ActionResult> CreateUnitOfMeasure([FromForm] UnitOfMeasureCommand unitOfMeasureCommand)
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);

            var unit = new UnitOfMeasureCommand(
                CompanyId: companyId,
                UnitName: unitOfMeasureCommand.UnitName,
                Symbol: unitOfMeasureCommand.Symbol,
                QuantityCode:unitOfMeasureCommand.QuantityCode

                );
            var Response = await _mediator.Send(unit);
            return Ok(Response);
        }


        [HttpPost("create-godowns")]

        public async Task<ActionResult> CreateGodowns( [FromForm] GodownCommand godownCommand)
        {

            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);

            var godown = new GodownCommand(
                CompanyId: companyId,
                GodownName: godownCommand.GodownName,
                Address: godownCommand.Address
                );
            var Response = await _mediator.Send(godown);
            return Ok(Response);
        }


        [HttpPost("create-stock-item")]

        public async Task<ActionResult> CreateStockItem([FromForm] StockItemCommand stockItemCommand)
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);
            var item = new StockItemCommand(
                CompanyId: companyId,
                ItemName: stockItemCommand.ItemName,
                GroupId: stockItemCommand.GroupId,
                CategoryId: stockItemCommand.CategoryId,
                UnitId: stockItemCommand.UnitId,
                OpeningQty: stockItemCommand.OpeningQty,
                OpeningRate: stockItemCommand.OpeningRate,
                IsGstApplicable: stockItemCommand.IsGstApplicable,

                HsnSacCode: stockItemCommand.HsnSacCode,
                   GstRate: stockItemCommand.GstRate,
                   TypeOfSupply: stockItemCommand.TypeOfSupply



                );
            var Response = await _mediator.Send(item);
            return Ok(Response);
        }



        [HttpGet("get-groups")]


        public async Task<ActionResult> RetriveStockGroups()
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);
            var groups = await _inventoryRepository.RetriveStockGroups(companyId);

            return Ok(groups);
        }

        [HttpGet("get-categories")]


        public async Task<ActionResult> RetriveStockCategories()
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);
            var groups = await _inventoryRepository.RetriveStockCategory(companyId);

            return Ok(groups);
        }

        [HttpGet("get-units")]
        public async Task<ActionResult> RetriveStockUnits()
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);
            var categories = await _inventoryRepository.RetriveStockUnits(companyId);

            return Ok(categories);
        }


        [HttpGet("get-items")]
        public async Task<ActionResult> RetriveStockItems()
        {
            if (!HttpContext.Items.TryGetValue("CompanyId", out var companyIdObj) || companyIdObj == null)
            {
                return Unauthorized("Company not found.");
            }
            var companyId = Convert.ToInt32(companyIdObj);
            var categories = await _inventoryRepository.RetriveStockItems(companyId);

            return Ok(categories);
        }

        [HttpGet("ledger-balance")]
        public async Task<ActionResult> RetriveLederBalance(int Id)
        {
            try
            {
                var balance = await _inventoryRepository.RetriveLedgerBalance(Id);
                return Ok(balance);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
    }
}
