using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Best.Route.Infrastructure.Data;

public static class AppDbContextExtensions
{
    public static void AddCommandDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CommandDbContext>(options => options.UseSqlite(connectionString));
    }


    public static void AddReadDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ReadDbContext>(options => options.UseSqlite(connectionString));
    }
}
