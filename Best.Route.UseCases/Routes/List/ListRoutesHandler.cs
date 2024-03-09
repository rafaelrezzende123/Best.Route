using Best.Route.Core.Entities.Interface;
using Best.Route.Core.Entities.Query;
using Best.Route.UseCases.Result;
using MediatR;


namespace Best.Route.UseCases.Routes.List;

public class ListRoutesHandler(IQueryDbContext _context) : IRequestHandler<ListRoutesQuery, Result<IEnumerable<RouteDTO>>>
{
    public async Task<Result<IEnumerable<RouteDTO>>> Handle(ListRoutesQuery request, CancellationToken cancellationToken)
    {
        string sql = @"select Id, Origin, Destination, Value from Routes";

        var result = await _context.GetRows<RoutesResponse>(sql);
        if (result is null || !result.Any())
            return Result<IEnumerable<RouteDTO>>.NotFound();


        var dto = result.Select(c => new RouteDTO(c.Id,
                                                  c.Origin,
                                                  c.Destination,
                                                  c.Value));

        return Result<IEnumerable<RouteDTO>>.Success(dto);
    }
}
