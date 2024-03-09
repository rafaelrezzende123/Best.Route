using Best.Route.Core.Entities.Interface;
using Best.Route.UseCases.Result;
using MediatR;


namespace Best.Route.UseCases.Routes.Create;

public class CreateRouteHandler(ICommandDbContext _context) : IRequestHandler<CreateRouteCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
    {
        var entity = Core.Entities.Route.Create(request.Origin, request.Destination, request.Value);
        await _context.Routes.AddAsync(entity);
        await _context.SaveChangesAsync();

        return Result<int>.Success(entity.Id);
    }
}
