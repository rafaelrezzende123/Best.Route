
using Best.Route.Core.Entities.Interface;
using Best.Route.UseCases.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Best.Route.UseCases.Routes.List;

public class ListRoutesHandler(IAppDbContext _context) : IRequestHandler<ListRoutesQuery, Result<IEnumerable<RouteDTO>>>
{
    public async Task<Result<IEnumerable<RouteDTO>>> Handle(ListRoutesQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Routes.ToListAsync();
        if (result is null || !result.Any())
            return Result<IEnumerable<RouteDTO>>.NotFound();


        var dto = result.Select(c => new RouteDTO(c.Id,
                                                  c.Origin,
                                                  c.Destination,
                                                  c.Value));

        return Result<IEnumerable<RouteDTO>>.Success(dto);
    }
}
