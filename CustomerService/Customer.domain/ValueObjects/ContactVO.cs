using System.Text.RegularExpressions;

namespace Customer.domain.ValueObjects;

public partial class ContactVO : IEquatable<ContactVO>
{
    public string Phone { get; }
    public string Email { get; }

    private ContactVO() { }

    public ContactVO(string phone, string email)
    {
        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Phone is required.", nameof(phone));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.", nameof(email));

        // Validação simples de e-mail (pode ser substituída por Regex mais forte)
        if (!email.Contains("@"))
            throw new ArgumentException("Invalid email format.", nameof(email));

        if (!MyRegex().IsMatch(email))
            throw new ArgumentException("Invalid email format.", nameof(email));

        if (!MyRegex1().IsMatch(phone))
            throw new ArgumentException("Invalid phone format. Must have 9 digits and start with 9.", nameof(phone));



        Phone = phone.Trim();
        Email = email.Trim();
    }
    public static ContactVO Create(string phone, string email)
    => new ContactVO(phone, email);

    public bool Equals(ContactVO? other)
    {
        if (other is null) return false;
        return Phone == other.Phone && Email == other.Email;
    }

    public override bool Equals(object? obj) => Equals(obj as ContactVO);
    public override int GetHashCode() => HashCode.Combine(Phone, Email);
    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    private static partial Regex MyRegex();
    [GeneratedRegex(@"^9\d{8}$")]
    private static partial Regex MyRegex1();
}
