using System;
using MediatR;

namespace Cineland.Application.Common.Messaging.Notifications
{
    public class Notification : Message, INotification
    {
        public Notification(string key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }

        public Guid Id { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
    }
}