using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands.Inventory_Masters
{
    public record StockGroupCommand(int CompanyId, string GroupName, string? Alias, int? ParentGroupId) : IRequest<string>;
}
