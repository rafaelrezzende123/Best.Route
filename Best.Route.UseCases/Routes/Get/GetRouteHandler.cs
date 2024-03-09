using Best.Route.Core.Entities.Interface;
using Best.Route.UseCases.Result;
using MediatR;


namespace Best.Route.UseCases.Routes.Get;

public class GetRouteHandler(IReadDbContext _context) : IRequestHandler<GetRouteQuery, Result<RouteDTO>>
{
    public async Task<Result<RouteDTO>> Handle(GetRouteQuery request, CancellationToken cancellationToken)
    {
        var entity = _context.Routes.FirstOrDefault(a => a.Id == request.RouteId);
        if (entity == null)
            return Result<RouteDTO>.NotFound();

        var dto = new RouteDTO(entity.Id, entity.Origin, entity.Destination, entity.Value);
        return Result<RouteDTO>.Success(dto);
    }
}
