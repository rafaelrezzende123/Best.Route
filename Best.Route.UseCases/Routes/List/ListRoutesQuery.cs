using Best.Route.UseCases.Result;
using MediatR;

namespace Best.Route.UseCases.Routes.List;

public record ListRoutesQuery(int? Skip, int? Take) : IRequest<Result<IEnumerable<RouteDTO>>>;
