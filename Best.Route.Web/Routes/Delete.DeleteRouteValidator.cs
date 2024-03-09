using FastEndpoints;
using FluentValidation;

namespace Best.Route.Web.Endpoints.RouteEndpoints;
public class DeleteRouteValidator : Validator<DeleteRouteRequest>
{
  public DeleteRouteValidator()
  {
    RuleFor(x => x.RouteId).GreaterThan(0);
  }
}
