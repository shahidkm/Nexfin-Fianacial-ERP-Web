using InventoryAndAccountingServices.Domain.Entities;

namespace InventoryAndAccountingServices.Application.Interfaces
{
    public interface IInventoryMastersRepository
    {
        Task<string> CreateStockGroup(StockGroup stockGroup);
        Task<string> CreateStockCategory(StockCategory stockCategory);
        Task<string> CreateUnitOfMeasure(UnitOfMeasure unitOfMeasure);
        Task<string> CreateGodown(Godown godown);
        Task<string> CreateStockItem(StockItem stockItem);
        Task<List<StockGroup>> RetriveStockGroups(int CompanyId);
        Task<List<StockCategory>> RetriveStockCategory(int CompanyId);
        Task<List<UnitOfMeasure>> RetriveStockUnits(int CompanyId);
        Task<List<StockItem>> RetriveStockItems(int CompanyId);
        Task<string> RetriveLedgerBalance(int Id);
    }
}
