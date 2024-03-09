
using Microsoft.EntityFrameworkCore;

namespace Best.Route.Core.Entities.Interface
{
    public interface IAppDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<Route> Routes { get; set; }
    }
}
