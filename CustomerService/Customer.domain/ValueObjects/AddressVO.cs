namespace Customer.domain.ValueObjects;

public class AddressVO : IEquatable<AddressVO>
{
    public string Street { get; }
    public string City { get; }
    public string Province { get; }
    public string ZipCode { get; }

    private AddressVO() { }

    public AddressVO(string street, string city, string province, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street is required.", nameof(street));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City is required.", nameof(city));
        if (string.IsNullOrWhiteSpace(province))
            throw new ArgumentException("Province is required.", nameof(province));
        if (string.IsNullOrWhiteSpace(zipCode))
            throw new ArgumentException("ZipCode is required.", nameof(zipCode));

        Street = street.Trim();
        City = city.Trim();
        Province = province.Trim();
        ZipCode = zipCode.Trim().ToUpperInvariant();
    }
    public static AddressVO Create(string street, string city, string province, string zipCode)
    => new AddressVO(street, city, province, zipCode);

    public override string ToString() => $"{Street}, {City}, {Province}, {ZipCode}";

    public bool Equals(AddressVO? other)
    {
        if (other is null) return false;
        return Street == other.Street &&
               City == other.City &&
               Province == other.Province &&
               ZipCode == other.ZipCode;
    }

    public override bool Equals(object? obj) => Equals(obj as AddressVO);
    public override int GetHashCode() => HashCode.Combine(Street, City, Province, ZipCode);
}
