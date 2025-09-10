namespace Customer.domain.Events;
public abstract class DomainEventBase
{
    public Guid EventId { get; }
    public DateTime OccurredOn { get; }

    protected DomainEventBase()
    {
        EventId = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }
}
