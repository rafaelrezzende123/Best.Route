using Best.Route.UseCases.Result;
using MediatR;

namespace Best.Route.UseCases.Routes.Get;

public record GetRouteQuery(int RouteId) : IRequest<Result<RouteDTO>>; 
