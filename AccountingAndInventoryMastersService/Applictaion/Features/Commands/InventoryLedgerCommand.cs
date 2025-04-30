using MediatR;

namespace AccountingAndInventoryMastersService.Applictaion.Features.Commands
{
    public record InventoryLedgerCommand(int CompanyId, string LedgerName, string? Alias, int GroupId) : IRequest<string>;
}
