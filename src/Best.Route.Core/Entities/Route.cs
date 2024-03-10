
using Best.Route.Core.Entities.Interface;

namespace Best.Route.Core.Entities;

public class Route(string origin, string destination, decimal value) : BaseEntity, IAuditEntity
{
    public string Origin { get; private set; } = origin;
    public string Destination { get; private set; } = destination;
    public decimal Value { get; private set; } = value;
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    public static Route Create(string origin, string destination, decimal value)
    {
        var model = new Route(origin, destination, value);
        return model;
    }


    public void Update(string origin, string destination, decimal value)
    {
        Origin = origin;
        Destination = destination;
        Value = value;
    }


}

