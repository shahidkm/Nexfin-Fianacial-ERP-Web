using Microsoft.Extensions.Caching.Distributed;

namespace LicenseService.Infrastucture.Services
{
    public class OtpService
    {

        private readonly IDistributedCache _cache;
        private readonly ResendEmailService _resendEmailService;
        public OtpService(IDistributedCache distributedCache ,ResendEmailService resendEmailService)
        {
            _cache = distributedCache;
            _resendEmailService = resendEmailService;
        }


        public async Task<string> SendOtp(string email)
        {
            var otp = new Random().Next(100000, 999999).ToString();
            await _cache.SetStringAsync(email, otp, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });


            var html = $"<h3>Your OTP is: {otp}</h3>";
            var success = await _resendEmailService.SendEmailAsync(email, "Your OTP Code", html);

            return success ? "OTP sent!" :  "Failed to send email.";
        }


        public async Task<bool> VerifyOtpAsync(string email, string otp)
        {
            var storedOtp = await _cache.GetStringAsync(email);
            return storedOtp == otp;
        }


    }
}
