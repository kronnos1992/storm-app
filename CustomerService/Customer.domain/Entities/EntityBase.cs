using Customer.domain.Events;
using Customer.domain.Interfaces;

namespace Customer.domain.Entities;

public abstract class EntityBase : IEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    private readonly List<DomainEventBase> _domainEvents = new();
    public IReadOnlyCollection<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected EntityBase()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    public void SetUpdated() => UpdatedAt = DateTime.UtcNow;

    // Domain Events
    protected void AddDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    public void RemoveDomainEvent(DomainEventBase domainEvent) => _domainEvents.Remove(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}
