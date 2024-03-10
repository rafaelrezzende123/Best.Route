using FastEndpoints;
using FluentValidation;

namespace Best.Route.Web.Endpoints.RouteEndpoints;

public class UpdateRouteValidator : Validator<UpdateRouteRequest>
{
    public UpdateRouteValidator()
    {
        RuleFor(x => x.Origin)
          .NotEmpty()
          .WithMessage("Origin is required.")
          .MinimumLength(3)
          .MaximumLength(3);

        RuleFor(x => x.Destination)
            .NotEmpty()
            .WithMessage("Destination is required.")
            .MinimumLength(3)
            .MaximumLength(3);

        RuleFor(x => x.Value)
           .NotNull()
           .GreaterThan(0)
           .WithMessage("Value is required.");

        RuleFor(x => x.RouteId)
          .Must((args, routeId) => args.Id == routeId)
          .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
    }
}
