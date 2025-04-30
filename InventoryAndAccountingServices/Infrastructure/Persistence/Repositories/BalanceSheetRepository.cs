using InventoryAndAccountingServices.Contracts;
using InventoryAndAccountingServices.Domain.Entities;
using InventoryAndAccountingServices.Domain.Enums;
using InventoryAndAccountingServices.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryAndAccountingServices.Infrastructure.Persistence.Repositories
{
    public class BalanceSheetRepository
    {
        private readonly AppDbContext _context;

        public BalanceSheetRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<BalanceSheetDto> GetBalanceSheetAsync(int companyId, DateTime asOnDate)
        {
            asOnDate = asOnDate.Date;

            // Load all groups
            var groups = await _context.InventoryGroups
                .Where(g => g.CompanyId == companyId && g.Nature != null)
                .Include(g => g.ChildGroups)
                .ToListAsync();

            // Load all ledgers
            var ledgers = await _context.InventoryLedgers
                .Where(l => l.CompanyId == companyId && l.GroupId != null)
                .ToListAsync();

            // Load all voucher entries until asOnDate
            var voucherEntries = await _context.VoucherEntries
                .Where(e => e.Ledger.CompanyId == companyId && e.Voucher.Date.Date <= asOnDate)
                .ToListAsync();

            // Calculate ledger balances from voucher entries
            var ledgerBalances = voucherEntries
                .GroupBy(e => e.LedgerId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(x => x.EntryType == EntryType.Debit ? x.Amount : -x.Amount)
                );

            // Group balances based on group id
            var balanceByGroup = ledgers
                .GroupBy(l => l.GroupId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(l => ledgerBalances.TryGetValue(l.LedgerId, out var bal) ? bal : 0)
                );

            // Build balance sheet lines
            BalanceSheetLine BuildLine(InventoryGroup g)
            {
                var own = balanceByGroup.TryGetValue(g.GroupId, out var bal) ? Math.Abs(bal) : 0m;

                var line = new BalanceSheetLine
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

            // Build Assets, Liabilities, Incomes, Expenses separately
            var assetGroups = groups
                .Where(g => g.ParentGroupId == null && g.Nature == GroupNature.Asset)
                .Select(BuildLine)
                .ToList();

            var liabilityGroups = groups
                .Where(g => g.ParentGroupId == null && g.Nature == GroupNature.Liability)
                .Select(BuildLine)
                .ToList();

            var incomeGroups = groups
                .Where(g => g.ParentGroupId == null && g.Nature == GroupNature.Income)
                .Select(BuildLine)
                .ToList();

            var expenseGroups = groups
                .Where(g => g.ParentGroupId == null && g.Nature == GroupNature.Expense)
                .Select(BuildLine)
                .ToList();

            // Calculate totals
            var totalAssets = assetGroups.Sum(g => g.Amount);
            var totalLiabilities = liabilityGroups.Sum(g => g.Amount);

            var totalIncome = incomeGroups.Sum(g => g.Amount);
            var totalExpenses = expenseGroups.Sum(g => g.Amount);

            // Calculate Net Profit or Loss
            decimal netProfit = totalIncome - totalExpenses;

            // Add Net Profit/Loss to Liabilities
            if (netProfit != 0)
            {
                var profitLossLine = new BalanceSheetLine
                {
                    GroupName = netProfit > 0 ? "Net Profit" : "Net Loss",
                    Amount = Math.Abs(netProfit),
                    Children = null
                };

                var capitalAccount = liabilityGroups.FirstOrDefault(l => l.GroupName == "Capital Account");

                if (capitalAccount != null)
                {
                    if (capitalAccount.Children == null)
                        capitalAccount.Children = new List<BalanceSheetLine>();

                    capitalAccount.Children.Add(profitLossLine);
                    capitalAccount.Amount += Math.Abs(netProfit);
                }
                else
                {
                    liabilityGroups.Add(new BalanceSheetLine
                    {
                        GroupName = "Capital Adjustment",
                        Amount = Math.Abs(netProfit),
                        Children = new List<BalanceSheetLine> { profitLossLine }
                    });
                }

                totalLiabilities += Math.Abs(netProfit);
            }

            return new BalanceSheetDto
            {
                Assets = assetGroups,
                Liabilities = liabilityGroups,
                TotalAssets = totalAssets,
                TotalLiabilities = totalLiabilities
            };
        }
    }
}
