//using System.Security.Cryptography;

//namespace LicenseService.Infrastructure.Services
//{
//    public class RsaKeyService
//    {
//        public static (string PrivateKey, string PublicKey) GenerateKeys()
//        {
//            using var rsa = RSA.Create(2048);
//            var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
//            var publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
//            return (privateKey, publicKey);
//        }
//    }
//}
