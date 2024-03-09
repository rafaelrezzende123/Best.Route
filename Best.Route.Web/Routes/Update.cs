using Best.Route.UseCases.Result;
using Best.Route.UseCases.Routes.Get;
using Best.Route.UseCases.Routes.Update;
using Best.Route.Web.Endpoints.RouteEndpoints;
using FastEndpoints;
using MediatR;


namespace Best.Route.Web.RouteEndpoints;

public class Update(IMediator _mediator) : Endpoint<UpdateRouteRequest, UpdateRouteResponse>
{
    public override void Configure()
    {
        Put(UpdateRouteRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateRouteRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateRouteCommand(request.Id, request.Origin, request.Destination, request.Value));

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        var dto = result.Value;
        Response = new UpdateRouteResponse(new RouteRecord(dto.Id, dto.Origin, dto.Destination, dto.Value));
        return;

    }
}

