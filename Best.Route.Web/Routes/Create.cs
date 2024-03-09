using FastEndpoints;
using Best.Route.Web.Endpoints.RouteEndpoints;
using MediatR;
using Best.Route.UseCases.Routes.Create;

namespace Best.Route.Web.RouteEndpoints;
public class Create(IMediator _mediator) : Endpoint<CreateRouteRequest, CreateRouteResponse>
{
    public override void Configure()
    {
        Post(CreateRouteRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateRouteRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateRouteCommand(request.Origin!, request.Destination!, request.Value));
        if (result.IsSuccess)
        {
            Response = new CreateRouteResponse(result);
            return;
        }
   
        return;

    }
}

