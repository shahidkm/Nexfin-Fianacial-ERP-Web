using System.Reflection;

namespace CompanyService.Application
{
    public static  class DependencyInjection
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
