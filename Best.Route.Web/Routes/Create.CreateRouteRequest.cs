using System.ComponentModel.DataAnnotations;

namespace Best.Route.Web.Endpoints.RouteEndpoints;

public class CreateRouteRequest
{
    public const string Route = "/Routes";

    [Required]
    public string Origin { get; set; }
    [Required]
    public string Destination { get; set; }
    [Required]
    public decimal Value { get; set; }
}

