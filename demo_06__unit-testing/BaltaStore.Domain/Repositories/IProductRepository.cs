using BaltaStore.Domain.Abstractions;
using BaltaStore.Domain.Entities;

namespace BaltaStore.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByIdAsync(Specification<Product> specification, CancellationToken cancellationToken = default);
}