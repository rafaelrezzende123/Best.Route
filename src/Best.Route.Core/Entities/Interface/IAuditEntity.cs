

namespace Best.Route.Core.Entities.Interface
{
    public interface IAuditEntity
    {
        DateTime CreatedAt { get; set; }

        DateTime ModifiedAt { get; set; }
    }
}
