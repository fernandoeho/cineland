using System.Linq;
using Cineland.Application.Common.Messaging.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cineland.API.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly NotificationHandler _notificationHandler;

        public ApiController(INotificationHandler<Notification> notificationHandler)
        {
            _notificationHandler = (NotificationHandler)notificationHandler;
        }

        protected new IActionResult Response(object result = null)
        {
            var notifications = _notificationHandler.GetNotifications();

            if (!_notificationHandler.HasNotifications())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificationHandler.GetNotifications().Select(error => error.Value)
            });
        }
    }
}