using Customer.domain.ValueObjects;
using Customer.domain.Events;

namespace Customer.domain.Entities;

public class Student : EntityBase
{
    public string Fullname { get; private set; }
    public string DocNumber { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public bool Status { get; private set; }

    public AddressVO? Address { get; private set; }
    public Guid GuardianId { get; private set; }
    public virtual Guardian Guardian { get; private set; }

    protected Student() { } // EF Core

    public Student(string fullname, string docNumber, Guid guardianId, DateTime dateOfBirth, AddressVO? address = null)
    {
        if (string.IsNullOrWhiteSpace(fullname))
            throw new ArgumentException("O nome do estudante é obrigatório.", nameof(fullname));

        if (dateOfBirth > DateTime.UtcNow)
            throw new ArgumentException("A data de nascimento não pode ser futura.", nameof(dateOfBirth));

        Fullname = fullname;
        DocNumber = docNumber;
        GuardianId = guardianId;
        DateOfBirth = dateOfBirth;
        Address = address;
        Status = true;

        AddDomainEvent(new StudentRegisteredEvent(Id, Fullname, GuardianId));
    }

    public void UpdateAddress(AddressVO newAddress)
    {
        Address = newAddress ?? throw new ArgumentNullException(nameof(newAddress));
        SetUpdated();

        AddDomainEvent(new StudentAddressUpdatedEvent(
            Id,
            newAddress.Street,
            newAddress.City,
            newAddress.Province,
            newAddress.ZipCode,
            DateTime.UtcNow
        ));
    }
    public void Deactivate()
    {
        Status = false;
        SetUpdated();
    }

    public void Activate()
    {
        Status = true;
        SetUpdated();
    }

}
