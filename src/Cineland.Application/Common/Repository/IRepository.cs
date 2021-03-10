using System.Threading;
using System.Threading.Tasks;

namespace Cineland.Application.Common.Repository
{
    public interface IRepository
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}