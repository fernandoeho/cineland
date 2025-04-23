namespace Cineland.Application.Mediator;

internal sealed class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var handler = _serviceProvider.GetService(handlerType);

        if (handler == null)
            throw new InvalidOperationException($"Request handler not found for {request.GetType().Name}");
        

        return await (Task<TResponse>)handlerType
            .GetMethod("Handle")!
            .Invoke(handler, new object[] {request, cancellationToken})!;
    }
}