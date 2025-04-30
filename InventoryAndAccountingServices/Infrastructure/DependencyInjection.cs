using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Infrastructure.Persistence.Repositories;

namespace InventoryAndAccountingServices.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IAccountingMastersRepositories,AccountingMastersRepository>();
            services.AddScoped<IInventoryMastersRepository, InventoryMastersRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<BalanceSheetRepository>();
            services.AddScoped<ProfitAndLossRepository>();
            return services;
        }
    }
}
