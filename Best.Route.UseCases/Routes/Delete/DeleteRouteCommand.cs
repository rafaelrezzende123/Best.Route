using Best.Route.UseCases.Result;
using MediatR;

namespace Best.Route.UseCases.Routes.Delete;

public record DeleteRouteCommand(int RouteId) : IRequest<Result<int>>;