using CompanyService.Application.Interfaces;
using CompanyService.Infrastructure.Persistence.Repositories;

namespace CompanyService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<ICompanyRepository,CompanyRepository>();
     

            return services;
        }
    }
}
