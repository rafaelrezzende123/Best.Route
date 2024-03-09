using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Best.Route.Infrastructure.Data;

public static class AppDbContextExtensions
{

    public static void AddCommandDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var commandDbConnection = configuration.GetConnectionString("CommandSqlConnection");
        services.AddDbContext<CommandDbContext>(options => options.UseSqlite(commandDbConnection));
    }


    public static void AddQueryDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var queryDbConnection = configuration.GetConnectionString("QuerySqlConnection");
        services.AddDbContext<QueryDbContext>(options => options.UseSqlite(queryDbConnection));
    }
}
