
namespace Best.Route.Core.Services;

public class Grafo
{
    private readonly Dictionary<string, Dictionary<string, decimal>> _vertices = new Dictionary<string, Dictionary<string, decimal>>();

    public void AdicionarVertice(string nome)
    {
        _vertices[nome] = new Dictionary<string, decimal>();
    }

    public void AdicionarAresta(string origem, string destino, decimal peso)
    {
        _vertices[origem][destino] = peso;
    }

    public List<string> Dijkstra(string origem, string destino)
    {
        var custos = new Dictionary<string, decimal>();
        var predecessores = new Dictionary<string, string>();
        var verticesNaoVisitados = new List<string>();

        foreach (var vertice in _vertices)
        {
            if (vertice.Key == origem)
                custos[vertice.Key] = 0;
            else
                custos[vertice.Key] = int.MaxValue;

            predecessores[vertice.Key] = null;
            verticesNaoVisitados.Add(vertice.Key);
        }

        while (verticesNaoVisitados.Count != 0)
        {
            verticesNaoVisitados.Sort((x, y) => (int)custos[x] - (int)custos[y]);
            var verticeAtual = verticesNaoVisitados.First();
            verticesNaoVisitados.Remove(verticeAtual);

            if (verticeAtual == destino)
            {
                var caminho = new List<string>();
                while (predecessores[verticeAtual] != null)
                {
                    caminho.Insert(0, verticeAtual);
                    verticeAtual = predecessores[verticeAtual];
                }
                caminho.Insert(0, origem);
                return caminho;
            }

            foreach (var vizinho in _vertices[verticeAtual])
            {
                var custoTotal = custos[verticeAtual] + vizinho.Value;
                if (custoTotal < custos[vizinho.Key])
                {
                    custos[vizinho.Key] = custoTotal;
                    predecessores[vizinho.Key] = verticeAtual;
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
}
