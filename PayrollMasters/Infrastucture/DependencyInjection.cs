using PayrollMasters.Application.Interfaces;
using PayrollMasters.Infrastucture.Persistence.Repositories;

namespace PayrollMasters.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository,EmployeeRepository>();

  

            return services;
        }
    }
}
