using Best.Route.UseCases.Result;
using Best.Route.UseCases.Routes.Delete;
using Best.Route.Web.Endpoints.RouteEndpoints;
using FastEndpoints;
using MediatR;

namespace Best.Route.Web.RouteEndpoints;

public class Delete(IMediator _mediator) : Endpoint<DeleteRouteRequest>
{
    public override void Configure()
    {
        Delete(DeleteRouteRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteRouteRequest request, CancellationToken cancellationToken)
    {
        var command = new DeleteRouteCommand(request.RouteId);

        var result = await _mediator.Send(command);

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        if (result.IsSuccess)
        {
            await SendNoContentAsync(cancellationToken);
        };
    }
}

