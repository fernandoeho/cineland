using System.Threading.Tasks;
using Cineland.Application.Mediator;
using Cineland.Application.Mediator.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cineland.UnitTests.Application;

public class RequestHandlerTests
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMediator _mediator;

    public RequestHandlerTests()
    {
        var services = new ServiceCollection();
        services.AddMediator(typeof(Ping).Assembly);
        _serviceProvider = services.BuildServiceProvider();
        _mediator = _serviceProvider.GetService<IMediator>()!;
    }

    public class Ping : IRequest<Pong>
    {
        public string? Message { get; set; }
    }

    public class Pong
    {
        public string? Message { get; set; }
    }

    public class PingHandler : IRequestHandler<Ping, Pong>
    {
        public Task<Pong> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Pong{ Message = request.Message + " Pong" });
        }
    }

    public class PingPong : IRequest<string>
    { }

    [Fact]
    public async Task PingRequestHandler_Should_Handle_Request()
    {
        var response = await _mediator.Send(new Ping { Message = "Ping"});
        Assert.Equal("Ping Pong", response.Message);
    }

    [Fact]
    public async Task Mediator_Should_ThrowException_WhenDoesNotHaveHandler() 
        => await Assert.ThrowsAsync<InvalidOperationException>(async () => await _mediator.Send(new PingPong()));
}