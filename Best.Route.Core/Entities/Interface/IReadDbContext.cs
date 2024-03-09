using Microsoft.EntityFrameworkCore;

namespace Best.Route.Core.Entities.Interface
{
    public interface IReadDbContext
    {
        DbSet<Route> Routes { get; set; }
    }
}
