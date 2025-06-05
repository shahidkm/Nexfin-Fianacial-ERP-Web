using CompanyServices.Application.Features.Commands;
using CompanyServices.Application.Features.Quaries;
using CompanyServices.Contracts;
using CompanyServices.Domain.Entities;

namespace CompanyServices.Application.Interfaces
{
    public interface ICompanyRepository
    {
        Task<string> CreateCompany(Company company);
        Task<List<Company>> RetreiveCompanyByUser(string UserId);
        Task<Company> RetriveCompanyById(int CompanyId);
        Task<bool> CheckCompany(int ConmpanyId);
        Task<string> SelectedCompany(int CompanyId);
        Task<string> CreateCompanyRole(CompanyRole companyRole);
        Task<string> GenerateRoleKey(string Email, int CompanyId);
        Task<List<Company>> RetriveAllCompanies();
        Task<List<Company>> RetriveBlockedCompanies();
        Task<List<Company>> RetriveActiveCompanies();
        Task<List<GetCompanyBasedRoleDto>> RetriveCompanyBasedRole(GetCompanyBasedRoleQuery getCompanyBasedRoleQuery);
        Task<string> EditCompany(EditCompanyCommand editCompanyCommand);
        Task<string> DeleteCompany(int CompanyId);
        Task<string>BlockorUnblock(int CompanyId);
        Task<List<CompanyRole>> RetriveUserRoles(string UserId);
        Task<List<CompanyRole>> RetriveAccountants(int companyId);
        Task<List<CompanyRole>> RetriveManagers(int companyId);
        Task<List<CompanyRole>> RetriveEmployees(int companyId);
    }
}
