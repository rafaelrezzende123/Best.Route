using FastEndpoints;
using Best.Route.Web.Endpoints.RouteEndpoints;
using MediatR;
using Best.Route.UseCases.Routes.Get;
using Best.Route.UseCases.Result;

namespace Best.Route.Web.RouteEndpoints;

public class Get(IMediator _mediator) : Endpoint<GetRouteRequest, string>
{
    public override void Configure()
    {
        Get(GetRouteRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetRouteRequest request, CancellationToken cancellationToken)
    {
        var command = new GetRouteQuery(request.Origin, request.Destination);

        var result = await _mediator.Send(command);

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        if (result.IsSuccess)
        {
            Response = result.Value;
        }
    }
}

