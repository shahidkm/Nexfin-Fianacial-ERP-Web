using AccountingAndInventoryMastersService.Applictaion.Interfaces;
using AccountingAndInventoryMastersService.Infrastructure.Persistence.Repositories;

namespace AccountingAndInventoryMastersService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IAccountingMastersRepository,AccountingMastersRepository>();
           

            return services;
        }
    }
}
