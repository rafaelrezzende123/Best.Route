namespace Best.Route.Core.Entities.Query.Routes;

public class RouteResponse
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public decimal Value { get; set; }
}
