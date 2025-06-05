using InventoryAndAccountingServices.Contracts;
using InventoryAndAccountingServices.Domain.Entities;
using InventoryAndAccountingServices.Domain.Enums;
using InventoryAndAccountingServices.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryAndAccountingServices.Infrastructure.Persistence.Repositories
{
    public class ProfitAndLossRepository
    {
        private readonly AppDbContext _context;

        public ProfitAndLossRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<ProfitAndLossDto> GetProfitAndLossAsync(int companyId, DateTime fromDate, DateTime toDate)
        {
            fromDate = fromDate.Date;
            toDate = toDate.Date;

            var groups = await _context.InventoryGroups
                .Where(g => g.CompanyId == companyId && g.Nature != null)
                .Include(g => g.ChildGroups)
                .ToListAsync();

            var ledgers = await _context.InventoryLedgers
                .Where(l => l.CompanyId == companyId && l.GroupId != null)
                .ToListAsync();

     
            var voucherEntries = await _context.VoucherEntries
                .Where(e => e.Ledger.CompanyId == companyId
                            && e.Voucher.Date.Date >= fromDate
                            && e.Voucher.Date.Date <= toDate)
                .ToListAsync();

            var ledgerBalances = voucherEntries
                .GroupBy(e => e.LedgerId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(x => x.EntryType == EntryType.Debit ? x.Amount : -x.Amount)
                );

            var balanceByGroup = ledgers
                .GroupBy(l => l.GroupId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(l => ledgerBalances.TryGetValue(l.LedgerId, out var bal) ? bal : 0)
                );

           
            ProfitAndLossLine BuildLine(InventoryGroup g)
            {
                var own = balanceByGroup.TryGetValue(g.GroupId, out var bal) ? Math.Abs(bal) : 0m;

                var line = new ProfitAndLossLine
                {
                    GroupName = g.GroupName,
                    Amount = own
                };

             
                if (g.ChildGroups?.Any() == true)
                {
                    line.Children = g.ChildGroups
                        .Select(BuildLine)
                        .Where(ch => ch.Amount != 0 || (ch.Children?.Any() == true))
                        .ToList();

                    line.Amount += line.Children.Sum(c => c.Amount);
                }

                return line;
            }

            
            var incomeGroups = groups
                .Where(g => g.ParentGroupId == null && g.Nature == GroupNature.Income)
                .Select(BuildLine)
                .ToList();

            var expenseGroups = groups
                .Where(g => g.ParentGroupId == null && g.Nature == GroupNature.Expense)
                .Select(BuildLine)
                .ToList();

    
            var totalIncome = incomeGroups.Sum(g => g.Amount);
            var totalExpenses = expenseGroups.Sum(g => g.Amount);

      
            decimal netProfitOrLoss = totalIncome - totalExpenses;

            return new ProfitAndLossDto
            {
                Income = incomeGroups,
                Expenses = expenseGroups,
                TotalIncome = totalIncome,
                TotalExpenses = totalExpenses,
                NetProfitOrLoss = netProfitOrLoss
            };
        }
    }
}
