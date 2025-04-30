using LicenseService.Application.Interfaces;
using LicenseService.Contracts.DTOs;
using Standard.Licensing;
using Standard.Licensing.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using LicenseService.Domain.Entites;
using LicenseService.Infrastucture.Persistence.Data;

namespace LicenseService.Infrastructure.Persistence.Repositories
{
    public class LicenseRepository : ILicenseRepository
    {
        private readonly AppDbContext _context;
        private readonly KeyGenerator _keyGenerator;

        public LicenseRepository(AppDbContext context, KeyGenerator keyGenerator)
        {
            _context = context;
            _keyGenerator = keyGenerator;
        }

        public async Task<string> GenerateLicenseKey(LicenseDto licenseDto)
        {
            try
            {
                licenseDto.ExpiryDate = DateTime.UtcNow.AddDays(30);

                var keyPair = _keyGenerator.GenerateKeyPair();
                var privateKey = keyPair.ToEncryptedPrivateKeyString("expresso-license-2025");
                var publicKey = keyPair.ToPublicKeyString();

                var license = License.New()
                    .WithUniqueIdentifier(Guid.Parse(licenseDto.UserId))
                    .As(LicenseType.Standard)
                    .ExpiresAt(licenseDto.ExpiryDate)
                    .LicensedTo(licenseDto.Fullname, licenseDto.Email)
                    .WithAdditionalAttributes(new Dictionary<string, string>
                    {
                        { "Address", licenseDto.Address },
                        { "Country", licenseDto.Country },
                        { "State", licenseDto.State },
                        { "District", licenseDto.District },
                        { "Pincode", licenseDto.Pincode }
                    })
                    .CreateAndSignWithPrivateKey(privateKey, "expresso-license-2025");

                var licenseKey = license.ToString();

                var licenseModel = new LicenseModel
                {
                    UserId = licenseDto.UserId,
                    Fullname = licenseDto.Fullname,
                    Email = licenseDto.Email,
                    Address = licenseDto.Address,
                    Country = licenseDto.Country,
                    State = licenseDto.State,
                    District = licenseDto.District,
                    Pincode = licenseDto.Pincode,
                    ExpiryDate = licenseDto.ExpiryDate,
                    LicenseKey = licenseKey,
                    PublicKey = publicKey
                };

                await _context.Licenses.AddAsync(licenseModel);
                await _context.SaveChangesAsync();

                return "License Created Successfully";
            }
            catch (Exception ex)
            {
                // Ideally log the error before returning
                return $"Error: {ex.Message}";
            }
        }
    }
}
