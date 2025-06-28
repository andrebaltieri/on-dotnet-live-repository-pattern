using BaltaStore.Domain.Abstractions;

namespace BaltaStore.Domain.Repositories;

public interface IRepository<T> where T : IAggregateRoot;