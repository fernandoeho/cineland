using MediatR;

namespace Cineland.Application.Common.Messaging
{
    public abstract class Command : Message, IRequest<bool>
    {
        protected Command() : base() { }
    }
}