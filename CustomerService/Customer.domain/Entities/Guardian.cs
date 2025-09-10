
using Customer.domain.Events;
using Customer.domain.ValueObjects;

namespace Customer.domain.Entities;
public class Guardian : EntityBase
{
    public string Fullname { get; private set; }
    public string DocNumber { get; private set; }
    public bool Status { get; private set; }

    public AddressVO Address { get; private set; }
    public ContactVO Contact { get; private set; }

    private readonly List<Student> _students = new();
    public IReadOnlyCollection<Student> Students => _students.AsReadOnly();

    protected Guardian() { } // EF Core

    public Guardian(string fullname, string docNumber, AddressVO address, ContactVO contact)
    {
        Fullname = fullname;
        DocNumber = docNumber;
        Address = address;
        Contact = contact;
        Status = true;

        AddDomainEvent(new GuardianRegisteredEvent(Id, fullname, docNumber, CreatedAt));
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
        SetUpdated();
    }
}
