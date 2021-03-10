using MediatR;

namespace Cineland.Application.Common.Messaging
{
    public abstract class Query<T> : Message, IRequest<T> where T : class
    {
        protected Query() : base() { }
    }
}