using Best.Route.UseCases.Result;
using MediatR;

namespace Best.Route.UseCases.Routes.Update;

public record UpdateRouteCommand(int RouteId, string Origin, string Destination, decimal Value) : IRequest<Result<RouteDTO>>;
