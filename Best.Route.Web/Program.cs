using Autofac;
using Autofac.Extensions.DependencyInjection;
using Best.Route.Core;
using Best.Route.Infrastructure;
using Best.Route.Infrastructure.Data;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>
{
    o.ShortSchemaNames = true;
});

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new CoreModule());
    containerBuilder.RegisterModule(new InfrastructureModule());
});

string? connectionString = builder.Configuration.GetConnectionString("SqliteConnection");
builder.Services.AddCommandDbContext(connectionString);
builder.Services.AddReadDbContext(connectionString);

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();
app.UseHttpsRedirection();

app.Run();

