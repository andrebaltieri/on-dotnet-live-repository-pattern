using BaltaStore.Domain.Entities;
using BaltaStore.Domain.Specifications.Products;

namespace BaltaStore.Infrastructure.Test;

public class GetProductByIdScpecificationTests
{
    private static readonly Guid Id = new("4d02d0b6-b6b1-4a95-9720-8acab6299493");

    private readonly List<Product> _products =
    [
        new() { Id = Id, Title = "Product 01" },
        new() { Id = Guid.NewGuid(), Title = "Product 02" }
    ];

    [Fact]
    public void ShouldGetProductById()
    {
        var spec = new GetProductByIdSpecification(Id);
        var product = _products.AsQueryable().Where(spec.ToExpression()).FirstOrDefault();
        Assert.NotNull(product);
    }

    [Fact]
    public void ShouldNotGetProductById()
    {
        var spec = new GetProductByIdSpecification(Guid.NewGuid());
        var product = _products.AsQueryable().Where(spec.ToExpression()).FirstOrDefault();
        Assert.Null(product);
    }
}