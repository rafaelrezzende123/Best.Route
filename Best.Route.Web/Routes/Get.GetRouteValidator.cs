using FastEndpoints;
using FluentValidation;

namespace Best.Route.Web.Endpoints.RouteEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetRouteValidator : Validator<GetRouteRequest>
{
    public GetRouteValidator()
    {
        RuleFor(x => x.RouteId).GreaterThan(0);
    }
}
