using Best.Route.Web.RouteEndpoints;

namespace Best.Route.Web.Endpoints.RouteEndpoints;


public class UpdateRouteResponse(RouteRecord route)
{
  public RouteRecord Route { get; set; } = route;
}
