using DataDriven.Models;

namespace DataDriven.Repositories.Abstractions;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
    Task<Product?> UpdateAsync(int id, Product product, CancellationToken cancellationToken = default);
    Task<Product?> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<Product?> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<List<Product>> GetAllAsync(int skip = 0, int take = 25, CancellationToken cancellationToken = default);
}