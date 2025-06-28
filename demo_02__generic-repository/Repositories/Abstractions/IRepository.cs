namespace DataDriven.Repositories.Abstractions;

public interface IRepository<T> where T : class
{
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task<T?> UpdateAsync(int id, T entity, CancellationToken cancellationToken = default);
    Task<T?> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<T?> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<List<T>> GetAllAsync(int skip = 0, int take = 25, CancellationToken cancellationToken = default);
}