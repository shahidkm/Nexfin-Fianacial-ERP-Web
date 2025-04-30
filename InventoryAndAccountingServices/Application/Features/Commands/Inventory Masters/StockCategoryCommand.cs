using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Commands.Inventory_Masters
{
 
        public record StockCategoryCommand(int CompanyId, string CategoryName, string? Alias) : IRequest<string>;
    
}
