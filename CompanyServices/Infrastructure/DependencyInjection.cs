using CompanyServices.Application.Interfaces;
using CompanyServices.Infrastructure.Persistanse.Repositories;
using CompanyServices.Infrastructure.Services;

namespace CompanyServices.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddHttpContextAccessor();
            services.AddScoped<CloudinaryService>();
            return services;
        }
    }
}
