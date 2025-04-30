using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Persistence.Repositories;
namespace UserService.Application
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
