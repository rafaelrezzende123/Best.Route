namespace Best.Route.Core.Entities.Query.Routes
{
    public class SqlRouteConstants
    {
        public const string GetAllRoutes = @"select Id, Origin, Destination, Value from Routes";
    }
}
