using Best.Route.Core.Entities.Interface;
using Microsoft.EntityFrameworkCore;

namespace Best.Route.Infrastructure.Data;
public class ReadDbContext : DbContext, IReadDbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> dbContextOptions) : base(dbContextOptions) { }
    public DbSet<Core.Entities.Route> Routes { get; set; }


}
