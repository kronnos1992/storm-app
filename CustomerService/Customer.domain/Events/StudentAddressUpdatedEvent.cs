namespace Customer.domain.Events;

public class StudentAddressUpdatedEvent(Guid studentId, string street, string city, string province, string zipCode, DateTime updatedAt) : DomainEventBase
{
    public Guid StudentId { get; } = studentId;
    public string Street { get; } = street;
    public string City { get; } = city;
    public string Province { get; } = province;
    public string ZipCode { get; } = zipCode;
    public DateTime UpdatedAt { get; } = updatedAt;
}

