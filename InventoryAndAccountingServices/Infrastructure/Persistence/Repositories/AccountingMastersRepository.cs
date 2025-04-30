using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Contracts;
using InventoryAndAccountingServices.Domain.Entities;
using InventoryAndAccountingServices.Domain.Enums;
using InventoryAndAccountingServices.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryAndAccountingServices.Infrastructure.Persistence.Repositories
{
    public class AccountingMastersRepository : IAccountingMastersRepositories
    {

        private readonly AppDbContext _context;
        public AccountingMastersRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;

        }


        public async Task<string> CreateInventoryGroup(InventoryGroup inventoryGroup)
        {
            try
            {
                inventoryGroup.CompanyId = inventoryGroup.CompanyId;
                await _context.InventoryGroups.AddAsync(inventoryGroup);
                await _context.SaveChangesAsync();

                return ("Created Successfully");
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public async Task<string> CreateInventoryLedger(InventoryLedger inventoryLedger)
        {
            await _context.InventoryLedgers.AddAsync(inventoryLedger);
            await _context.SaveChangesAsync();

            return ("Created Successfully");
        }

        public async Task<List<GetInventoryGroupsDto>> GetInventoryGroup(int CompanyId)
        {
            var groups = await _context.InventoryGroups.Where(i => i.CompanyId == CompanyId)
                .Select(g => new GetInventoryGroupsDto
                {
                    GroupId = g.GroupId,
                    CompanyId = g.CompanyId,
                    GroupName = g.GroupName,
                    Alias = g.Alias,
                    ParentName = g.ParentGroup != null ? _context.InventoryGroups.Where(i => i.GroupId == g.ParentGroupId).Select(p => p.GroupName).FirstOrDefault() : null
                }).ToListAsync();


            return groups;
        }



        public async Task<List<GetInventoryLedgerDto>> GetInventoryLedger(int CompanyId)
        {
            var groups = await _context.InventoryGroups.ToListAsync();

            var ledgers = await _context.InventoryLedgers
                .Where(i => i.CompanyId == CompanyId)
                .ToListAsync();

            var result = ledgers.Select(l => new GetInventoryLedgerDto
            {
                CompanyId = l.CompanyId,
                GroupName = groups.FirstOrDefault(g => g.GroupId == l.GroupId)?.GroupName,
                Alias = l.Alias,
                DrCr = l.DrCr,
                OpeningBalance = l.OpeningBalance,
                Balance = l.Balance
            }).ToList();


            return result;
        }


        public async Task<string> CreateDefaultInventoryGroupsAsync(int companyId)
        {
            // 1) Don’t reseed if any groups already exist for this company
            if (await _context.InventoryGroups.AnyAsync(g => g.CompanyId == companyId))
                return "Default groups already exist for this company.";

            // 2) Define the 15 primary groups (Balance-Sheet + P&L) with Nature
            var rootDefs = new List<(string Name, GroupNature Nature)>
    {
        // Assets
        ("Branch / Divisions",             GroupNature.Asset),
        ("Current Assets",                 GroupNature.Asset),
        ("Fixed Assets",                   GroupNature.Asset),
        ("Investments",                    GroupNature.Asset),
        ("Miscellaneous Expenses (Asset)", GroupNature.Asset),
        ("Suspense A/c",                   GroupNature.Asset),

        // Liabilities
        ("Capital Account",                GroupNature.Liability),
        ("Current Liabilities",            GroupNature.Liability),
        ("Loans (Liability)",              GroupNature.Liability),
        ("Reserves & Surplus",             GroupNature.Liability),

        // Income (P&L treated as Liability-side)
        ("Direct Income",                  GroupNature.Liability),
        ("Indirect Income",                GroupNature.Liability),
        ("Sales Accounts",                 GroupNature.Liability),

        // Expenses (P&L treated as Asset-side)
        ("Direct Expenses",                GroupNature.Asset),
        ("Indirect Expenses",              GroupNature.Asset),
        ("Purchase Accounts",              GroupNature.Asset)
    };

            // 3) Seed the root InventoryGroups
            var roots = rootDefs.Select(def => new InventoryGroup
            {
                CompanyId = companyId,
                GroupName = def.Name,
                Alias = def.Name
                                       .Replace(" ", "_")
                                       .Replace("/", "_")
                                       .Replace("&", "AND")
                                       .Replace("(", "")
                                       .Replace(")", "")
                                       .ToUpperInvariant(),
                ParentGroupId = null,
                Nature = def.Nature,
                SubLedger = "Yes",
                NetBalance = "Yes",
                AllocateInPurchase = "No",
                CreatedDate = DateTime.Now
            }).ToList();

            await _context.InventoryGroups.AddRangeAsync(roots);
            await _context.SaveChangesAsync();

            // 4) Seed common children under “Current Assets” & “Current Liabilities”
            var currentAssetsId = roots.Single(g => g.GroupName == "Current Assets").GroupId;
            var currentLiabilitiesId = roots.Single(g => g.GroupName == "Current Liabilities").GroupId;

            var children = new[]
            {
        new InventoryGroup {
            CompanyId          = companyId,
            GroupName          = "Cash‐in‐Hand",
            Alias              = "CASH_IN_HAND",
            ParentGroupId      = currentAssetsId,
            Nature             = GroupNature.Asset,
            SubLedger          = "Yes",
            NetBalance         = "Yes",
            AllocateInPurchase = "No",
            CreatedDate        = DateTime.Now
        },
        new InventoryGroup {
            CompanyId          = companyId,
            GroupName          = "Bank Accounts",
            Alias              = "BANK_ACCOUNTS",
            ParentGroupId      = currentAssetsId,
            Nature             = GroupNature.Asset,
            SubLedger          = "Yes",
            NetBalance         = "Yes",
            AllocateInPurchase = "No",
            CreatedDate        = DateTime.Now
        },
        new InventoryGroup {
            CompanyId          = companyId,
            GroupName          = "Sundry Debtors",
            Alias              = "SUNDRY_DEBTORS",
            ParentGroupId      = currentAssetsId,
            Nature             = GroupNature.Asset,
            SubLedger          = "Yes",
            NetBalance         = "Yes",
            AllocateInPurchase = "No",
            CreatedDate        = DateTime.Now
        },
        new InventoryGroup {
            CompanyId          = companyId,
            GroupName          = "Duties & Taxes",
            Alias              = "DUTIES_AND_TAXES",
            ParentGroupId      = currentLiabilitiesId,
            Nature             = GroupNature.Liability,
            SubLedger          = "Yes",
            NetBalance         = "Yes",
            AllocateInPurchase = "No",
            CreatedDate        = DateTime.Now
        },
        new InventoryGroup {
            CompanyId          = companyId,
            GroupName          = "Sundry Creditors",
            Alias              = "SUNDRY_CREDITORS",
            ParentGroupId      = currentLiabilitiesId,
            Nature             = GroupNature.Liability,
            SubLedger          = "Yes",
            NetBalance         = "Yes",
            AllocateInPurchase = "No",
            CreatedDate        = DateTime.Now
        }
    };

            await _context.InventoryGroups.AddRangeAsync(children);
            await _context.SaveChangesAsync();

            return "Default inventory-groups (including account-natures) seeded successfully.";
        }

    }
}
