﻿using FastEndpoints;
using FluentValidation;
namespace Best.Route.Web.Endpoints.RouteEndpoints;


public class CreateRouteValidator : Validator<CreateRouteRequest>
{
    public CreateRouteValidator()
    {
        RuleFor(x => x.Origin)
          .NotEmpty()
          .WithMessage("Origin is required.")
          .MinimumLength(2)
          .MaximumLength(100);

        RuleFor(x => x.Destination)
          .NotEmpty()
          .WithMessage("Origin is required.")
          .MinimumLength(2)
          .MaximumLength(100);

        RuleFor(x => x.Value)
           .NotNull()
           .GreaterThan(0)
           .WithMessage("Value is required.");
    }
}