using FastEndpoints;
using MediatR;
using Best.Route.Web.Endpoints.RouteEndpoints;
using Best.Route.UseCases.Routes.List;

namespace Best.Route.Web.RouteEndpoints;

public class List(IMediator _mediator) : EndpointWithoutRequest<RouteListResponse>
{
    public override void Configure()
    {
        Get("/Routes");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new ListRoutesQuery(null, null));

        if (result.IsSuccess)
        {
            Response = new RouteListResponse
            {
                Routes = result.Value.Select(c => new RouteRecord(c.Id,
                                                                  c.Origin,
                                                                  c.Destination,
                                                                  c.Value)).ToList()
            };
        }
    }
}
