using Best.Route.Core.Entities.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Best.Route.Infrastructure.Data;
public class CommandDbContext : DbContext, ICommandDbContext
{
    public CommandDbContext(DbContextOptions<CommandDbContext> dbContextOptions) : base(dbContextOptions) { }
    public DbSet<Core.Entities.Route> Routes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IAuditEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));


        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                ((IAuditEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
            }
            else
            {
                Entry((IAuditEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
            }


            ((IAuditEntity)entityEntry.Entity).ModifiedAt = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
