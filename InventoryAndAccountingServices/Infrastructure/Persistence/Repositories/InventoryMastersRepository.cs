using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Domain.Entities;
using InventoryAndAccountingServices.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryAndAccountingServices.Infrastructure.Persistence.Repositories
{
    public class InventoryMastersRepository :IInventoryMastersRepository
    {
        private readonly AppDbContext _context;


        public InventoryMastersRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<string> CreateStockGroup(StockGroup stockGroup)
        {
            try
            {
                await _context.StockGroups.AddAsync(stockGroup);
                await _context.SaveChangesAsync();

                return ("Created Successfully");
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
    

      public async Task<string> CreateStockCategory(StockCategory stockCategory)
        {
            try
            {
                await _context.StockCategories.AddAsync(stockCategory);
                await _context.SaveChangesAsync();

                return ("Created Successfully");
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

        public async Task<string> CreateUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            try
            {
                await _context.UnitOfMeasures.AddAsync(unitOfMeasure);
                await _context.SaveChangesAsync();

                return ("Created Successfully");
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

        public async Task<string> CreateGodown(Godown godown)
        {
            try
            {
                await _context.Godowns.AddAsync(godown);
                await _context.SaveChangesAsync();

                return ("Created Successfully");
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public async Task<string> CreateStockItem(StockItem stockItem)
        {
            try
            {
                await _context.StockItems.AddAsync(stockItem);
                await _context.SaveChangesAsync(); 
                return "Created Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public async Task<List<StockGroup>> RetriveStockGroups(int CompanyId)
        {
            var groups = await _context.StockGroups.Where(g => g.CompanyId == CompanyId).ToListAsync();
            return groups;
        }

        public async Task<List<StockCategory>> RetriveStockCategory(int CompanyId)
        {
            var categories = await _context.StockCategories.Where(g => g.CompanyId == CompanyId).ToListAsync();
            return categories;
        }

        public async Task<List<UnitOfMeasure>> RetriveStockUnits(int CompanyId)
        {
            var units = await _context.UnitOfMeasures.Where(g => g.CompanyId == CompanyId).ToListAsync();
            return units;
        }
    }

}
