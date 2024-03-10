namespace Best.Route.Web.Endpoints.RouteEndpoints;
public record DeleteRouteRequest
{
  public const string Route = "/Routes/{RouteId:int}";
  public static string BuildRoute(int routeId) => Route.Replace("{RouteId:int}", routeId.ToString());

  public int RouteId { get; set; }
}
