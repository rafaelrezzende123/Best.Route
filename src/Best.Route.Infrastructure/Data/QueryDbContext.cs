using Best.Route.Core.Entities.Interface;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Best.Route.Infrastructure.Data;
public class QueryDbContext : DbContext, IQueryDbContext
{
    public QueryDbContext(DbContextOptions<QueryDbContext> dbContextOptions) : base(dbContextOptions) { }

    public async Task<IEnumerable<T>> GetRows<T>(string sql)
    {
        using (var connection = this.Database.GetDbConnection())
        {
            return await connection.QueryAsync<T>(sql);
        }
    }

    public async Task<T> GetRow<T>(string sql)
    {
        using (var connection = this.Database.GetDbConnection())
        {
            return await connection.QueryFirstAsync<T>(sql);
        }
    }


}
