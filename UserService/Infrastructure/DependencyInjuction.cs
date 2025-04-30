using Microsoft.EntityFrameworkCore;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Persistence.Data;
using UserService.Infrastructure.Persistence.Repositories;
using DotNetEnv;
using UserService.Infrastructure.Services;
namespace UserService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<JwtService>();
            services.AddScoped<TokenWithCompany>();
            return services;
        }
    }

}
