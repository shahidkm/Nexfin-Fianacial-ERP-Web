using System.Reflection;

namespace InventoryAndAccountingServices.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
