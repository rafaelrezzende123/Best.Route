using System.ComponentModel.DataAnnotations;

namespace Best.Route.Web.Endpoints.RouteEndpoints;


public class UpdateRouteRequest
{
    public const string Route = "/Routes/{RouteId:int}";
    public static string BuildRoute(int routeId) => Route.Replace("{RouteId:int}", routeId.ToString());

    public int RouteId { get; set; }

    [Required]
    public int Id { get; set; }
    [Required]
    public string Origin { get; set; }
    [Required]
    public string Destination { get; set; }
    [Required]
    public decimal Value { get; set; }
}
