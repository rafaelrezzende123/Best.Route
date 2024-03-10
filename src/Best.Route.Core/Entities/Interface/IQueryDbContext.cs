using Microsoft.EntityFrameworkCore;

namespace Best.Route.Core.Entities.Interface
{
    public interface IQueryDbContext
    {
        Task<IEnumerable<T>> GetRows<T>(string sql);
        Task<T> GetRow<T>(string sql);
    }
}
