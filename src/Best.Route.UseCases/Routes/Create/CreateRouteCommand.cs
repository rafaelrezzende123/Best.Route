using Best.Route.UseCases.Result;
using MediatR;

namespace Best.Route.UseCases.Routes.Create;

public record CreateRouteCommand(string Origin, string Destination, decimal Value) : IRequest<Result<int>>;
