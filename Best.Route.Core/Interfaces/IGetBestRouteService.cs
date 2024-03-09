
namespace Best.Route.Core.Interfaces;
public interface IGetBestRouteService
{
    Task<string> GetBestRoute(string origin, string destination);
}
