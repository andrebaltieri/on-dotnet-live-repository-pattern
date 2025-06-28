using BaltaStore.Domain.Entities;
using BaltaStore.Domain.Repositories;
using BaltaStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BaltaStore.Infrastructure.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) 
        => await context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
}