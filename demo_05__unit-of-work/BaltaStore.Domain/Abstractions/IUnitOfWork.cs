namespace BaltaStore.Domain.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync();
}