using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Cineland.Application.Mediator.Extensions;

public static class MediatorServiceCollectionExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services, Assembly assembly)
    { 
        services.AddScoped<IMediator, Mediator>();

        RegisterRequestHandlers(services, assembly);

        return services;
    }

    private static void RegisterRequestHandlers(IServiceCollection services, Assembly assembly)
    {
        var requestHandlerTypes = assembly.GetTypes()
            .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
            .ToList();
        
        foreach (var requestHandlerType in requestHandlerTypes)
        {
            var requestHandlerInterface = requestHandlerType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));
            
            services.AddScoped(requestHandlerInterface, requestHandlerType);
        }
    }
}