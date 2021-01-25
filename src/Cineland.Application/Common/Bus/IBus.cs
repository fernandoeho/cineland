using System.Threading.Tasks;
using Cineland.Application.Common.Messaging;

namespace Cineland.Application.Common.Bus
{
    public interface IBus
    {
        Task<bool> RequestAsync<T>(T command) where T : Command;
        Task NotifyAsync<T>(T @event) where T : Event;
    }
}