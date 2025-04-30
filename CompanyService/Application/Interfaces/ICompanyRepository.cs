using CompanyService.Domain.Entities;

namespace CompanyService.Application.Interfaces
{
    public interface ICompanyRepository
    {
        Task<string> CreateCompany(Company company);
        Task<List<Company>> RetreiveCompanyByUser(string UserId);
        Task<Company> SelectCompany(int ConmpanyId,string UserId);
        Task<string> CreateCompanyRole(CompanyRole companyRole);
    }
}
