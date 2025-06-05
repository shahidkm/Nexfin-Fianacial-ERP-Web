using PayrollMasters.Application.Interfaces;
using PayrollMasters.Infrastucture.Persistence.Repositories;
using PayrollService.Application.Interfaces;
using PayrollService.Infrastucture.Persistence.Repositories;
using PayrollService.Infrastucture.Persistence.Services;
using PayrollService.Infrastucture.Persistence.Services.CloudinaryServices;

namespace PayrollMasters.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            services.AddScoped<IAttendenceRepository,AttendenceRepository>();
            services.AddScoped<ICloudinaryService,CloudinaryService>();


            return services;
        }
    }
}
