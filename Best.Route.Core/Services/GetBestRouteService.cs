using Best.Route.Core.Entities.Interface;
using Best.Route.Core.Entities.Query.Routes;
using Best.Route.Core.Interfaces;


namespace Best.Route.Core.Services;

public class GetBestRouteService(IQueryDbContext _context) : IGetBestRouteService
{
    public async Task<string> GetBestRoute(string origin, string destination)
    {
        var rotes = await _context.GetRows<RouteResponse>(SqlRouteConstants.GetAllRoutes);
        if (rotes is null)
            return null;

        var cities = rotes.SelectMany(a => new[] { a.Origin, a.Destination }).Distinct().ToList();
        return Grafo.Dijkstra(cities, rotes.ToList(), origin, destination);
    }
}
