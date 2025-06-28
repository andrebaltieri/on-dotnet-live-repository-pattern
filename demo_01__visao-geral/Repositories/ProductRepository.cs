using DataDriven.Data;
using DataDriven.Models;
using DataDriven.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DataDriven.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return product;
    }

    public async Task<Product?> UpdateAsync(int id, Product product, CancellationToken cancellationToken = default)
    {
        var current = await context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (current is null)
            return null;

        current.Title = product.Title;

        context.Update(current);
        await context.SaveChangesAsync(cancellationToken);

        return current;
    }

    public async Task<Product?> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (product is null)
            return null;

        context.Remove(product);
        await context.SaveChangesAsync(cancellationToken);

        return product;
    }

    public async Task<Product?> GetAsync(int id, CancellationToken cancellationToken = default)
        => await context.Products.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

    public async Task<List<Product>> GetAllAsync(int skip = 0, int take = 25,
        CancellationToken cancellationToken = default)
        => await context.Products.AsNoTracking().Skip(skip).Take(take).ToListAsync(cancellationToken) ?? [];
}