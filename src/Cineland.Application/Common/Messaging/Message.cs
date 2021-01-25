using System;

namespace Cineland.Application.Common.Messaging
{
    public abstract class Message
    {
        protected Message()
        {
            MessageType = GetType().Name;
            DateTimeStamp = DateTime.UtcNow;
        }

        public string MessageType { get; private set; }
        public DateTime DateTimeStamp { get; private set; }
    }
}