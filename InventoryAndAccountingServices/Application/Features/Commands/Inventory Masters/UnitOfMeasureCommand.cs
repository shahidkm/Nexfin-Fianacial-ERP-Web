using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands.Inventory_Masters
{
    public record UnitOfMeasureCommand(int CompanyId, string UnitName, string Symbol, string QuantityCode) : IRequest<string>;
}
