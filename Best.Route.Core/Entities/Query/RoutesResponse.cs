

namespace Best.Route.Core.Entities.Query;

public class RoutesResponse
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public decimal Value { get; set; }
}
