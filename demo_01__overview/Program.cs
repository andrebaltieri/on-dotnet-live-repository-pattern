using DataDriven.Data;
using DataDriven.Models;
using DataDriven.Repositories;
using DataDriven.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<IProductRepository, ProductRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/v1/products", async (CancellationToken token, IProductRepository repository, int skip = 0, int take = 25)
    => Results.Ok(await repository.GetAllAsync(skip, take, token)));

app.MapGet("/v1/products/{id}", async (CancellationToken token, IProductRepository repository, int id)
    => Results.Ok(await repository.GetAsync(id)));

app.MapPost("/v1/products", async (CancellationToken token, IProductRepository repository, Product product)
    => Results.Ok(await repository.CreateAsync(product, token)));

app.MapPut("/v1/products/{id}", async (CancellationToken token, IProductRepository repository, int id, Product product)
    => Results.Ok(await repository.UpdateAsync(id, product, token)));

app.MapDelete("/v1/products/{id}", async (CancellationToken token, IProductRepository repository, int id)
    => Results.Ok(await repository.DeleteAsync(id, token)));

app.Run();