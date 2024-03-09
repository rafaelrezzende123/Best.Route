using Best.Route.Core.Interfaces;
using Best.Route.UseCases.Result;
using MediatR;

namespace Best.Route.UseCases.Routes.Get;

public class GetRouteHandler(IGetBestRouteService _service) : IRequestHandler<GetRouteQuery, Result<string>>
{
    public async Task<Result<string>> Handle(GetRouteQuery request, CancellationToken cancellationToken)
    {
        var result = await _service.GetBestRoute(request.Origin, request.Destination);
        if (result is null)
            return Result<string>.NotFound();

        return Result<string>.Success(result);
    }
}
