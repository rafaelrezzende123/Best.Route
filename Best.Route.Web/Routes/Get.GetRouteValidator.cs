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
        RuleFor(x => x.Origin)
              .NotEmpty()
              .WithMessage("Origin is required.")
              .MinimumLength(3)
              .MaximumLength(3);

        RuleFor(x => x.Destination)
              .NotEmpty()
              .WithMessage("Origin is required.")
              .MinimumLength(3)
              .MaximumLength(3);
    }
}
