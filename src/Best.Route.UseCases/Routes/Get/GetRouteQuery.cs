using Best.Route.UseCases.Result;
using MediatR;

namespace Best.Route.UseCases.Routes.Get;

public record GetRouteQuery(string Origin, string Destination) : IRequest<Result<string>>;
