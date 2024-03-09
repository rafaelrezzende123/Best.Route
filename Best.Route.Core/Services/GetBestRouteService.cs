using Best.Route.Core.Entities.Interface;
using Best.Route.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Best.Route.Core.Services;

public class GetBestRouteService(IQueryDbContext _context) : IGetBestRouteService
{
    public async Task<string> GetBestRoute(string origin, string destination)
    {
        var rotes = await _context.Routes.ToListAsync();
        if (rotes is null)
            return "Não foi possível encontrar uma rota para os destinos fornecidos.";

        var cities = rotes.SelectMany(a => new[] { a.Origin, a.Destination }).Distinct().ToList();
        return Grafo.Dijkstra(cities, rotes, origin, destination);
    }
}
