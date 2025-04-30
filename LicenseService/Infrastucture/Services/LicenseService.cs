//using LicenseService.Domain.Entites;
//using Microsoft.Extensions.Options;
//using System.Security.Cryptography;
//using System.Text;
//using System.Text.Json;

//namespace LicenseService.Infrastructure.Services
//{
//    public class LicenseServices
//    {
//        private readonly string _privateKey;
//        private readonly string _publicKey;

//        public LicenseServices(IOptions<LicenseKeyOptions> options)
//        {
//            _privateKey = options.Value.PrivateKey;
//            _publicKey = options.Value.PublicKey;

//            // Verify that the keys are valid Base-64 encoded strings.
//            try
//            {
//                Convert.FromBase64String(_privateKey);
//                Convert.FromBase64String(_publicKey);
//            }
//            catch (FormatException ex)
//            {
//                throw new InvalidOperationException("One of the RSA keys is not a valid Base-64 string.", ex);
//            }
//        }

//        public string GenerateLicense(LicenseModel license)
//        {
//            var json = JsonSerializer.Serialize(license);
//            var data = Encoding.UTF8.GetBytes(json);

//            using var rsa = RSA.Create();
//            // This line will now succeed if _privateKey is valid Base-64.
//            rsa.ImportRSAPrivateKey(Convert.FromBase64String(_privateKey), out _);

//            var signature = rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
//            return Convert.ToBase64String(signature) + "." + Convert.ToBase64String(data);
//        }

//        public bool ValidateLicense(string licenseString)
//        {
//            try
//            {
//                var parts = licenseString.Split('.');
//                if (parts.Length != 2)
//                    return false;

//                var signature = Convert.FromBase64String(parts[0]);
//                var data = Convert.FromBase64String(parts[1]);

//                using var rsa = RSA.Create();
//                rsa.ImportRSAPublicKey(Convert.FromBase64String(_publicKey), out _);

//                var isValid = rsa.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
//                if (!isValid)
//                    return false;

//                var license = JsonSerializer.Deserialize<LicenseModel>(Encoding.UTF8.GetString(data));
//                return license != null && license.ExpiryDate > DateTime.UtcNow;
//            }
//            catch
//            {
//                return false;
//            }
//        }
//    }
//}
