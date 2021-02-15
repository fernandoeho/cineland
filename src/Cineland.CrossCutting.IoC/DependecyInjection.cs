using Cineland.Application;
using Cineland.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Cineland.CrossCutting.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure();
            return services;
        }
    }
}