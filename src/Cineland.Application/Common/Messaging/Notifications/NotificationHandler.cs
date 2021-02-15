using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Cineland.Application.Common.Messaging.Notifications
{
    public class NotificationHandler : INotificationHandler<Notification>
    {
        private List<Notification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        public Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public IReadOnlyCollection<Notification> GetNotifications() => _notifications.AsReadOnly();

        public bool HasNotifications() => _notifications.Any();
    }
}