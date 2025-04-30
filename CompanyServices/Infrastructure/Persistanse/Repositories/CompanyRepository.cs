using CompanyServices.Application.Features.Commands;
using CompanyServices.Application.Features.Quaries;
using CompanyServices.Application.Interfaces;
using CompanyServices.Contracts;
using CompanyServices.Domain.Entities;
using CompanyServices.Infrastructure.Persistanse.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CompanyServices.Infrastructure.Persistanse.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<CompanyRepository> _logger;
        public CompanyRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor, ILogger<CompanyRepository> logger)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<string> CreateCompany(Company company)
        {
            if (company.Name == null)
            {
                _logger.LogError("Name is required.");
                return "Name is required.";
            }

            if (company.Address == null)
            {
                _logger.LogError("Address is required.");
                return "Name is required.";
            }

            if (company.State == null)
            {
                _logger.LogError("State is required.");
                return "State is required.";
            }

            if (company.Pincode == null)
            {
                _logger.LogError("Pincode is required.");
                return "Pincode is required.";
            }

            if (company.GSTIN == null)
            {
                _logger.LogError("GSTIN is required.");
                return "GSTIN is required.";
            }

            if (company.PAN == null)
            {
                _logger.LogError("PAN is required.");
                return "PAN is required.";
            }

            if (company.FinancialYearFrom == null)
            {
                _logger.LogError("FinancialYearFrom is required.");
                return "FinancialYearFrom is required.";
            }
            if (company.BooksBeginFrom == null)
            {
                _logger.LogError("BooksBeginFrom is required.");
                return "BooksBeginFromc is required.";
            }
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return "Company created successfully";
        }

        public async Task<List<Company>> RetreiveCompanyByUser(string userId)
        {

            var response = await _context.Companies
                .Where(c => c.UserId == userId)
                .ToListAsync();
            if (response == null)
            {
                _logger.LogInformation("User havent any company.");
            }
            return response;
        }

        public async Task<bool> CheckCompany(int companyId)
        {
            var response = await _context.Companies
                .FirstOrDefaultAsync(c => c.CompanyId == companyId);


            if (response == null)
            {
                _logger.LogError("Company not found.");
                return false;
            }
            return true;
        }

        public async Task<string> SelectedCompany(int companyId)
        {
            var response = await _context.Companies
                .FirstOrDefaultAsync(c => c.CompanyId == companyId);
             if (response == null)
            {
                _logger.LogInformation("User havent any company.");
            }
            return response?.Name ?? "Company not found";
        }

        public async Task<string> CreateCompanyRole(CompanyRole companyRole)
        {

            await _context.CompanyRoles.AddAsync(companyRole);
            await _context.SaveChangesAsync();
            
            return "Company role added successfully";
        }


        public async Task<string> GenerateRoleKey(string email, int companyId)
        {
            // Combine input into a single string
            string rawData = $"{email}:{companyId}:{Guid.NewGuid()}";

            // Create a SHA256 hash of the raw data
            using var sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Convert to base64 and clean it to remove non-password friendly characters
            string base64 = Convert.ToBase64String(hash)
                .Replace("+", "")
                .Replace("/", "")
                .Replace("=", "");

            // Take the first 8 characters
            return base64.Substring(0, 8);
        }


        public async Task<List<Company>> RetriveAllCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            return companies;
        }

        public async Task<List<Company>> RetriveBlockedCompanies()
        {
            var companies = await _context.Companies.Where(C=>C.IsActive==false).ToListAsync();
            if (companies == null)
            {
                _logger.LogInformation("No blocked companies.");
                return null;
            }
            return companies;
        }
        public async Task<List<Company>> RetriveActiveCompanies()
        {
            var companies = await _context.Companies.Where(C => C.IsActive == true).ToListAsync();
            if (companies == null)
            {
                _logger.LogInformation("No active companies.");
                return null;
            }
            return companies;
        }

        public async Task<List<GetCompanyBasedRoleDto>> RetriveCompanyBasedRole(GetCompanyBasedRoleQuery getCompanyBasedRoleQuery)
        {
            var companyWithRoles = await _context.CompanyRoles
    .Where(cr => cr.Email == getCompanyBasedRoleQuery.Email)
    .Select(cr => new GetCompanyBasedRoleDto
    {
        CompanyId = cr.CompanyId,
        Name = cr.Company.Name,
        Role = cr.Type

    })
    .ToListAsync();
            return companyWithRoles;
        }



        public async Task<Company> RetriveCompanyById(int CompanyId)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == CompanyId);
            return company;
        }


        public async Task<string>EditCompany(EditCompanyCommand command)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == command.CompanyId);

            if (company == null)
            {
                _logger.LogInformation("Company not found.");
                return "Company not found.";
            }


            company.Name = command.Name;
            company.Phone = command.Phone;
            
            company.State = command.State;
            company.Country = command.Country;
            company.District = command.District;
            company.GSTIN = command.GSTIN;
            company.PAN = command.PAN;
            company.FinancialYearFrom = command.FinancialYearFrom;
            company.BooksBeginFrom = command.BooksBeginFrom;
            company.Address = command.Address;
            company.Pincode = command.Pincode;

            await _context.SaveChangesAsync();
            return ("Company edited successfully.");
        }

        public async Task<string>DeleteCompany(int CompanyId)
        {
            if (CompanyId == 0)
            {
                _logger.LogError("Company Id not found");
                return ("Company id not found.");
            }

            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == CompanyId);
            if(company == null)
            {
                _logger.LogError("Company not found.");
                return ("Company not found.");
            }

             _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return ("Company deleted successfully.");

        }


        public async Task<string> BlockorUnblock(int CompanyId)
        {
            if (CompanyId == 0)
            {
                _logger.LogError("Company Id not found");
                return "Company id not found.";
            }

            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == CompanyId);
            if (company == null)
            {
                _logger.LogError("Company not found.");
                return "Company not found.";
            }

            if (company.IsActive == true)
            {
                company.IsActive = false;
                await _context.SaveChangesAsync();
                return "Company blocked.";
            }
            else
            {
                company.IsActive = true;
                await _context.SaveChangesAsync();
                return "Company unblocked.";
            }
        }


        public async Task<List<CompanyRole>>RetriveUserRoles(string Email)
        {
            if (Email == null)
            {
                _logger.LogError("Email not Found");
                
            }

            var roles = await _context.CompanyRoles.Where(r => r.Email == Email).ToListAsync();

            return roles;
        }


    }
}