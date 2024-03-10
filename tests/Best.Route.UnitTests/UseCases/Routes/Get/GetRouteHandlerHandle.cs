using Best.Route.Core.Interfaces;
using Best.Route.UseCases.Routes.Get;
using NSubstitute;
using FluentAssertions;
using Xunit;
using Autofac.Core;

namespace Best.Route.UnitTests.UseCases.Routes.Get;
public class GetRouteHandlerHandle
{
    private readonly IGetBestRouteService _service = Substitute.For<IGetBestRouteService>();
    private GetRouteHandler _handler;
    public GetRouteHandlerHandle()
    {
        _handler = new GetRouteHandler(_service);
    }
    [Fact]
    public async Task Handle_Returns_Success_Result_When_Service_Returns_Route()
    {
        // Arrange
        var origin = "GRU";
        var destination = "CDG";
        var route = "GRU -> BRC -> SCL -> ORL -> CDG ao custo de R$ 40,00";
        var query = new GetRouteQuery(origin, destination);

        _service.GetBestRoute(origin, destination).Returns(Task.FromResult<string?>(route));
        
        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(route, result.Value);
    }

    [Fact]
    public async Task Handle_Returns_NotFound_Result_When_Service_Returns_Null()
    {
        // Arrange
        var origin = "GRU";
        var destination = "CDG";

        var query = new GetRouteQuery(origin, destination);

        _service.GetBestRoute(origin, destination).Returns(Task.FromResult<string?>(null));
        
        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
    }
}
