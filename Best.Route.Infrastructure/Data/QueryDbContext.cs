using Best.Route.Core.Entities.Interface;
using Microsoft.EntityFrameworkCore;

namespace Best.Route.Infrastructure.Data;
public class QueryDbContext : DbContext, IQueryDbContext
{
    public QueryDbContext(DbContextOptions<QueryDbContext> dbContextOptions) : base(dbContextOptions) { }
    public DbSet<Core.Entities.Route> Routes { get; }


}
