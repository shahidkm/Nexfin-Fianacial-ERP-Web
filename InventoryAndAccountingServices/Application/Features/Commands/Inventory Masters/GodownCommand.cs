using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands.Inventory_Masters
{
  public record GodownCommand(int CompanyId, string GodownName, string? Address):IRequest<string>;
}
