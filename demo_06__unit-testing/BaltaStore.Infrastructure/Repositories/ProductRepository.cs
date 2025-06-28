using BaltaStore.Domain.Abstractions;
using BaltaStore.Domain.Entities;
using BaltaStore.Domain.Repositories;
using BaltaStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BaltaStore.Infrastructure.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product?> GetByIdAsync(Specification<Product> specification, CancellationToken cancellationToken = default) 
        => await context
            .Products
            .AsNoTracking()
            .Where(specification.ToExpression())
            .FirstOrDefaultAsync(cancellationToken);
}