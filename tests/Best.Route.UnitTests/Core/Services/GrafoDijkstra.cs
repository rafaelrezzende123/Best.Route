using Best.Route.Core.Entities.Query.Routes;
using Best.Route.Core.Services;
using NSubstitute;


namespace Best.Route.UnitTests.Core.Services
{
    public class GrafoDijkstra
    {
        [Fact]
        public void Dijkstra_ReturnsCorrectResult()
        {
            // Arrange
            var origin = "A";
            var destination = "C";
            var cities = new List<string> { "A", "B", "C" };
            var routes = new List<RouteResponse>
            {
                new RouteResponse { Origin = "A", Destination = "B", Value = 5 },
                new RouteResponse { Origin = "B", Destination = "C", Value = 3 },
                new RouteResponse { Origin = "A", Destination = "C", Value = 10 }
            };


            // Act
            var result = Grafo.Dijkstra(cities, routes, origin, destination);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("A -> B -> C ao custo de R$ 8,00", result);
        }

        [Fact]
        public void Dijkstra_ReturnsNulltResult()
        {
            // Arrange
            var origin = "C";
            var destination = "D";
            var cities = new List<string> { "A", "B", "C" };
            var routes = new List<RouteResponse>
            {
                new RouteResponse { Origin = "A", Destination = "B", Value = 5 },
                new RouteResponse { Origin = "B", Destination = "C", Value = 3 },
                new RouteResponse { Origin = "A", Destination = "C", Value = 10 }
            };


            // Act
            var result = Grafo.Dijkstra(cities, routes, origin, destination);

            // Assert
            Assert.Null(result);
        }

    }
}
