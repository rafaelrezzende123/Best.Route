﻿using Best.Route.Core.Entities.Interface;
using Best.Route.Core.Entities.Query;
using Best.Route.Core.Interfaces;


namespace Best.Route.Core.Services;

public class GetBestRouteService(IQueryDbContext _context) : IGetBestRouteService
{
    public async Task<string> GetBestRoute(string origin, string destination)
    {
        string sql = @"select Id, Origin, Destination, Value from Routes";
        var rotes = await _context.GetRows<RoutesResponse>(sql);
        if (rotes is null)
            return "Não foi possível encontrar uma rota para os destinos fornecidos.";

        var cities = rotes.SelectMany(a => new[] { a.Origin, a.Destination }).Distinct().ToList();
        return Grafo.Dijkstra(cities, rotes.ToList(), origin, destination);
    }
}
