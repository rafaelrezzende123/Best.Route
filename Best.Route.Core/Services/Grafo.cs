
using Best.Route.Core.Entities;

namespace Best.Route.Core.Services;

public class Grafo
{
    private static readonly Dictionary<string, Dictionary<string, decimal>> _vertices = new Dictionary<string, Dictionary<string, decimal>>();


    public static string Dijkstra(List<string> cities, List<Entities.Route> rotes, string origin, string destination)
    {
        cities.ForEach(x => AddVertex(x));
        rotes.ForEach(x => AddEdge(x.Origin, x.Destination, x.Value));
        var segment = Dijkstra(origin, destination);

        if (segment.Count > 0)
        {
            var custoTotal = CalculateTotalCost(segment);
            return $"{string.Join(" -> ", segment)} ao custo de R${custoTotal}";
        }

        return "Não foi possível encontrar uma rota para os destinos fornecidos.";
    }

    private static List<string> Dijkstra(string origin, string destination)
    {
        var costs = new Dictionary<string, decimal>();
        var predecessors = new Dictionary<string, string>();
        var unvisitedVertices = new List<string>();

        foreach (var vertex in _vertices)
        {
            if (vertex.Key == origin)
                costs[vertex.Key] = 0;
            else
                costs[vertex.Key] = int.MaxValue;

            predecessors[vertex.Key] = null;
            unvisitedVertices.Add(vertex.Key);
        }

        while (unvisitedVertices.Count != 0)
        {
            unvisitedVertices.Sort((x, y) => (int)costs[x] - (int)costs[y]);
            var currentVertex = unvisitedVertices.First();
            unvisitedVertices.Remove(currentVertex);

            if (currentVertex == destination)
            {
                var path = new List<string>();
                while (predecessors[currentVertex] != null)
                {
                    path.Insert(0, currentVertex);
                    currentVertex = predecessors[currentVertex];
                }
                path.Insert(0, origin);
                return path;
            }

            foreach (var neighbor in _vertices[currentVertex])
            {
                var totalCost = costs[currentVertex] + neighbor.Value;
                if (totalCost < costs[neighbor.Key])
                {
                    costs[neighbor.Key] = totalCost;
                    predecessors[neighbor.Key] = currentVertex;
                }
            }
        }

        return new List<string>();
    }

    public decimal GetPesoAresta(string origem, string destino)
    {
        if (_vertices.ContainsKey(origem) && _vertices[origem].ContainsKey(destino))
        {
            return _vertices[origem][destino];
        }
        return int.MaxValue;
    }


    private static decimal CalculateTotalCost(List<string> segment)
    {
        decimal totalCost = 0;
        for (int i = 0; i < segment.Count - 1; i++)
        {
            var origin = segment[i];
            var destination = segment[i + 1];
            totalCost += GetEdgeWeight(origin, destination);
        }
        return totalCost;
    }


    private static void AddVertex(string name)
    {
        _vertices[name] = new Dictionary<string, decimal>();
    }

    private static void AddEdge(string origin, string destination, decimal peso)
    {
        _vertices[origin][destination] = peso;
    }

    private static decimal GetEdgeWeight(string origin, string destination)
    {
        if (_vertices.ContainsKey(origin) && _vertices[origin].ContainsKey(destination))
        {
            return _vertices[origin][destination];
        }
        return int.MaxValue;
    }
}
