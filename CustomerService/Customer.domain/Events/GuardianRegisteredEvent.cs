namespace Customer.domain.Events;

public class GuardianRegisteredEvent(Guid guardianId, string fullname, string docNumber, DateTime registeredAt) : DomainEventBase
{
    public Guid GuardianId { get; } = guardianId;
    public string Fullname { get; } = fullname;
    public string DocNumber { get; } = docNumber;
    public DateTime RegisteredAt { get; } = registeredAt;
}
