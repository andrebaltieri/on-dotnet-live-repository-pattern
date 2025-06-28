using BaltaStore.Domain.Abstractions;

namespace BaltaStore.Domain.Entities;

public class Product : Entity, IAggregateRoot
{
    public string Title { get; set; } = string.Empty;
}