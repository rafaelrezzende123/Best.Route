using System.ComponentModel.DataAnnotations;

namespace Best.Route.Web.Endpoints.RouteEndpoints;
public class GetRouteRequest
{
    public const string Route = "/Routes/{Origin}/{Destination}";
    public static string BuildRoute(string origin, string destination) => Route.Replace("{Origin}", origin)
                                                                               .Replace("{Destination}", destination);

    public string Origin { get; set; }
    public string Destination { get; set; }
}
