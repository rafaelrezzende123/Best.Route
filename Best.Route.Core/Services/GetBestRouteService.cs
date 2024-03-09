using Autofac.Core;
using Best.Route.Core.Entities.Interface;
using Best.Route.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Best.Route.Core.Services;

public class GetBestRouteService(IQueryDbContext _context) : IGetBestRouteService
{
    public Grafo _grafo { get; set; }
    public async Task<string> GetBestRoute(string origin, string destination)
    {
        _grafo = new Grafo();
        var rotes = await _context.Routes.ToListAsync();
        var citys = new List<string>();
        var citysOrigin = rotes.Select(a=> a.Origin).Distinct().ToList();
        citys.AddRange(citysOrigin);
        var citysDestination = rotes.Select(a => a.Destination).Distinct().ToList();
        citys.AddRange(citysDestination);
        citys = citys.Distinct().ToList();
        
        citys.ForEach(x => _grafo.AdicionarVertice(x));
        rotes.ForEach(x => _grafo.AdicionarAresta(x.Origin, x.Destination, x.Value));

        var caminho = _grafo.Dijkstra(origin, destination);
        if (caminho.Count > 0)
        {
            var custoTotal = CalcularCustoTotal(caminho);
            return $"{string.Join(" -> ", caminho)} ao custo de R${custoTotal}";
        }
        else
        {
            return "Não foi possível encontrar uma rota para os destinos fornecidos.";
        }

    }

    private decimal CalcularCustoTotal(List<string> caminho)
    {
        decimal custoTotal = 0;
        for (int i = 0; i < caminho.Count - 1; i++)
        {
            var origem = caminho[i];
            var destino = caminho[i + 1];
            custoTotal += _grafo.GetPesoAresta(origem, destino);
        }
        return custoTotal;
    }
}
