using DataDriven.Data;
using DataDriven.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DataDriven.Repositories;

public abstract class Repository<T>(DbContext context) : IRepository<T>
    where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<T?> UpdateAsync(int id, T entity, CancellationToken cancellationToken = default)
    {
        // _dbSet.Entry(entity).State = EntityState.Modified;
        _dbSet.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<T?> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetAsync(id, cancellationToken);
        if (entity is null)
            return null;

        _dbSet.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<T?> GetAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync(id, cancellationToken);

    public async Task<List<T>> GetAllAsync(int skip = 0, int take = 25, CancellationToken cancellationToken = default)
        => await _dbSet.AsNoTracking().Skip(skip).Take(take).ToListAsync(cancellationToken);
}