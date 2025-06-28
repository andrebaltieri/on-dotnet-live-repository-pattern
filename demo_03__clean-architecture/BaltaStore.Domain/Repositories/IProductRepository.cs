using BaltaStore.Domain.Entities;

namespace BaltaStore.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}