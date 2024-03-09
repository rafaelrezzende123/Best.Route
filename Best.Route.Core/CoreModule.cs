using Autofac;
using Best.Route.Core.Entities.Interface;
using Best.Route.Core.Interfaces;
using Best.Route.Core.Services;
namespace Best.Route.Core;

public class CoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GetBestRouteService>().As<IGetBestRouteService>().InstancePerLifetimeScope();
    }
}
