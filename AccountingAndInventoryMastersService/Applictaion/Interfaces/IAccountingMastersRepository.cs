using AccountingAndInventoryMastersService.Domain.Entities;

namespace AccountingAndInventoryMastersService.Applictaion.Interfaces
{
    public interface IAccountingMastersRepository
    {

        Task<string> CreateInventoryGroup(InventoryGroup inventoryGroup);
        Task<string> CreateInventoryLedger(InventoryLedger inventoryLedger);
    }
}
