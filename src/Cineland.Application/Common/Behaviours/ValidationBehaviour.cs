using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cineland.Application.Common.Messaging.Notifications;
using FluentValidation;
using MediatR;

namespace Cineland.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private IEnumerable<IValidator<TRequest>> _validators;
        private readonly NotificationHandler _notificationHandler;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, INotificationHandler<Notification> notificationHandler)
        {
            _notificationHandler = (NotificationHandler)notificationHandler;
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Any())
                {
                    foreach (var failure in failures)
                    {
                        await _notificationHandler.Handle(new Notification(failure.PropertyName, failure.ErrorMessage), cancellationToken);
                    }

                    return default(TResponse);
                }
            }

            return await next();
        }
    }
}