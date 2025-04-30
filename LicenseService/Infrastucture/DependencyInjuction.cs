using LicenseService.Application.Interfaces;

using LicenseService.Domain.Entites;
using Standard.Licensing.Security.Cryptography;
using LicenseService.Infrastucture.Services;
using LicenseService.Infrastructure.Persistence.Repositories;
namespace LicenseService.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILicenseRepository, LicenseRepository>();

            services.Configure<LicenseKeyOptions>(
                configuration.GetSection("LicenseKeys"));

         
            services.AddSingleton<KeyGenerator>();
            services.AddSingleton<ResendEmailService>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
                options.InstanceName = "NexfinOtp";

            });
            services.AddScoped<OtpService>();
            return services;
        }
    }

}
