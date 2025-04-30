using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands
{
    public record InventoryGroupCommand(int ?CompanyId, string GroupName, string? Alias, int? ParentGroupId, string? SubLedger, string? NetBalance, string? AllocateInPurchase) : IRequest<string>;
}
