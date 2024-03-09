using Best.Route.Core.Entities.Interface;
using Best.Route.UseCases.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Best.Route.UseCases.Routes.Delete;

public class DeleteRouteHandler(ICommandDbContext _context) : IRequestHandler<DeleteRouteCommand, Result<int>>
{
    public async Task<Result<int>> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Routes.Where(a => a.Id == request.RouteId).FirstOrDefaultAsync();

        if (entity == null)
            return Result<int>.NotFound();

        _context.Routes.Remove(entity);
        await _context.SaveChangesAsync();

        return Result<int>.Success(entity.Id);
    }
}
