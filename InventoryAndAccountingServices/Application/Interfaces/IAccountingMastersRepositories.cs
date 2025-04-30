using InventoryAndAccountingServices.Contracts;
using InventoryAndAccountingServices.Domain.Entities;

namespace InventoryAndAccountingServices.Application.Interfaces
{
    public interface IAccountingMastersRepositories
    {
        Task<string> CreateInventoryGroup(InventoryGroup inventoryGroup);
        Task<string> CreateInventoryLedger(InventoryLedger inventoryLedger);
        Task<List<GetInventoryGroupsDto>> GetInventoryGroup(int CompanyId);
        Task<List<GetInventoryLedgerDto>> GetInventoryLedger(int CompanyId);
        Task<string> CreateDefaultInventoryGroupsAsync(int companyId);
    }
}
