using Customer.domain.Entities;
using Customer.domain.Interfaces;

namespace Customer.app.DTOs;

public class GuardianDto : IDto<Guardian>
{
    public Guid Id { get; set; }
    public string Fullname { get; set; } = string.Empty;
    public string DocNumber { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool Status { get; set; }

    public void MapFromEntity(Guardian entity)
    {
        Id = entity.Id;
        Fullname = entity.Fullname;
        DocNumber = entity.DocNumber;
        PhoneNumber = entity.Contact.Phone;
        Email = entity.Contact.Email;
        Status = entity.Status;
    }
}