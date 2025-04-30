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

        public ProfitAndLossRepository(AppDbContext context)
        {
            _context = context;
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
                .Where(l => l.CompanyId == companyId && l.CreatedDate.Date >= fromDate && l.CreatedDate.Date <= toDate && l.GroupId != null)
                .ToListAsync();

            var balanceByGroup = ledgers
                .GroupBy(l => l.GroupId)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Balance));

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
                .Where(g => g.ParentGroupId == null && (g.Nature == GroupNature.Income))
                .Select(BuildLine)
                .ToList();

            var expenseGroups = groups
                .Where(g => g.ParentGroupId == null && (g.Nature == GroupNature.Expense))
                .Select(BuildLine)
                .ToList();

            var totalIncome = incomeGroups.Sum(i => i.Amount);
            var totalExpenses = expenseGroups.Sum(e => e.Amount);

            var netProfitOrLoss = totalIncome - totalExpenses;

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
