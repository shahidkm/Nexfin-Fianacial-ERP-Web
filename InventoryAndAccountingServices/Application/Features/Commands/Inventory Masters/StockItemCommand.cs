using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands.Inventory_Masters
{
    public record StockItemCommand(int CompanyId, string ItemName, int? GroupId, int? CategoryId, int? UnitId, decimal ?OpeningQty, decimal ?OpeningRate, string? IsGstApplicable, string? HsnSacCode, string? GstRate, string? TypeOfSupply) : IRequest<string>;
}
