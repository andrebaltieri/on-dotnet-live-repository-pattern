using BaltaStore.Application;
using BaltaStore.Domain;
using BaltaStore.Infrastructure;
using BaltaStore.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Configuration.ConnectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new Exception("ConnectionString não encontrada");

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(Configuration.ConnectionString, b
        => b.MigrationsAssembly("BaltaStore.Api"));
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("v1/products/{id}", async (
    ISender sender,
    Guid id,
    CancellationToken cancellationToken) =>
{
    var query = new BaltaStore.Application.UseCases.Products.GetById.Query(id);
    var result = await sender.Send(query, cancellationToken);

    return result.IsSuccess
        ? Results.Ok(result.Value)
        : Results.BadRequest(result.Error);
});

app.Run();