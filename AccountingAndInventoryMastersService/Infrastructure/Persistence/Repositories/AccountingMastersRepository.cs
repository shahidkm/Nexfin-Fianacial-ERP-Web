using AccountingAndInventoryMastersService.Applictaion.Interfaces;
using AccountingAndInventoryMastersService.Domain.Entities;
using AccountingAndInventoryMastersService.Infrastructure.Persistence.Data;

namespace AccountingAndInventoryMastersService.Infrastructure.Persistence.Repositories
{
    public class AccountingMastersRepository : IAccountingMastersRepository
    {

        private readonly AppDbContext _context;
        public AccountingMastersRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        public async Task<string> CreateInventoryGroup(InventoryGroup inventoryGroup)
        {
            await _context.AddAsync(inventoryGroup);
            _context.SaveChangesAsync();

            return ("Created Successfully");
        }
        public async Task<string> CreateInventoryLedger(InventoryLedger inventoryLedger)
        {     await _context.AddAsync(inventoryLedger);
            _context.SaveChangesAsync();

            return ("Created Successfully");
        }
    }
}
