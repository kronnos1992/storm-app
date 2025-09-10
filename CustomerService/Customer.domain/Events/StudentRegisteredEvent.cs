namespace Customer.domain.Events;

public class StudentRegisteredEvent(Guid studentId, string fullname, Guid guardianId) : DomainEventBase
{
    public Guid StudentId { get; } = studentId;
    public string Fullname { get; } = fullname;
    public Guid GuardianId { get; } = guardianId;
    public DateTime RegisteredAt { get; } = DateTime.UtcNow;
}
