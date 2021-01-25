using System;
using MediatR;

namespace Cineland.Application.Common.Messaging
{
    public abstract class Event : Message, INotification
    {
        protected Event(Guid aggregateId)
            : base()
        {
            AggregateId = aggregateId;
        }

        public Guid AggregateId { get; private set; }
    }
}