using LicenseService.Contracts.DTOs;
using LicenseService.Domain.Entites;


namespace LicenseService.Application.Interfaces
{
    public interface ILicenseRepository
    {
        Task<string> GenerateLicenseKey(LicenseDto licenseDto);
    }
}
