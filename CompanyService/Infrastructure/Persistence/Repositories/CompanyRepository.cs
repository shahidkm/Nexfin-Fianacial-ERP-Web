using CompanyService.Application.Interfaces;
using CompanyService.Domain.Entities;
using CompanyService.Infrastructure.Persistence.Data;

using Microsoft.EntityFrameworkCore;

namespace CompanyService.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateCompany(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return "Company created successfully";
        }

        public async Task<List<Company>> RetreiveCompanyByUser(string userId)
        {
            var response = await _context.Companies
                .Where(c => c.UserId == userId)
                .ToListAsync();

            return response;
        }

        public async Task<Company?> SelectCompany(int companyId, string userId)
        {
            var response = await _context.Companies
                .FirstOrDefaultAsync(c => c.CompanyId == companyId);

            if (response == null || response.UserId != userId)
            {
                return null;
            }

            return response;
        }

        public async Task<string> CreateCompanyRole(CompanyRole companyRole)
        {
            await _context.CompanyRoles.AddAsync(companyRole);
             _context.SaveChangesAsync();
            return "Company role added successfully";
        }
    }
}
