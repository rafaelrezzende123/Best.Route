using Best.Route.Core.Entities.Interface;
using Best.Route.UseCases.Result;
using MediatR;



namespace Best.Route.UseCases.Routes.Update;

public class UpdateRouteHandler(IAppDbContext _context) : IRequestHandler<UpdateRouteCommand, Result<RouteDTO>>
{
    public async Task<Result<RouteDTO>> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
    {
        var entity = _context.Routes.FirstOrDefault(a => a.Id == request.RouteId);
        if (entity == null)
            return Result<RouteDTO>.NotFound();

        entity.Update(request.Origin, request.Destination, request.Value);
        await _context.SaveChangesAsync();


        var dto = new RouteDTO(entity.Id, entity.Origin, entity.Destination, entity.Value);
        return Result<RouteDTO>.Success(dto);

    }
}
