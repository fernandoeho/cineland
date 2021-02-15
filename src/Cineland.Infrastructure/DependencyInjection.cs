using Cineland.Application.Common.Bus;
using Cineland.Infrastructure.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace Cineland.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBus, MediatRBus>();
            return services;
        }
    }
}