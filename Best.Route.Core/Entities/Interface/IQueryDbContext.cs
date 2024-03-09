using Microsoft.EntityFrameworkCore;

namespace Best.Route.Core.Entities.Interface
{
    public interface IQueryDbContext
    {
        DbSet<Route> Routes { get; }
    }
}
