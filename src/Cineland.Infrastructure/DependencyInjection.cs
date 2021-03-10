using Cineland.Application.Common.Bus;
using Cineland.Application.Entities.Movies.Repository;
using Cineland.Infrastructure.Bus;
using Cineland.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cineland.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBus, MediatRBus>();
            services.AddSingleton<IMovieRepository, MovieRepository>();
            return services;
        }
    }
}