using BaltaStore.Domain.Abstractions;

namespace BaltaStore.Infrastructure.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync() 
        => await context.SaveChangesAsync();
}