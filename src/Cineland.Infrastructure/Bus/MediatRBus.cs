using System.Threading.Tasks;
using Cineland.Application.Common.Bus;
using Cineland.Application.Common.Messaging;
using Cineland.Application.Common.Messaging.Notifications;
using MediatR;

namespace Cineland.Infrastructure.Bus
{
    public class MediatRBus : IBus
    {
        private readonly IMediator _mediator;
        private readonly INotificationHandler<Notification> _notificationHandler;

        public MediatRBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task NotifyAsync<T>(T @event) where T : Event
        {
            await _mediator.Publish(@event);
        }

        public async Task<bool> RequestAsync<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}