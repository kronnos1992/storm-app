using Customer.domain.Entities;
using Customer.domain.Interfaces;

namespace Customer.app.DTOs;
public class StudentDto : IDto<Student>
{
    public Guid Id { get; set; }
    public string Fullname { get; set; } = string.Empty;
    public string DocNumber { get; set; } = string.Empty;
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? ZipCode { get; set; }
    public Guid GuardianId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Status { get; set; }

    public void MapFromEntity(Student entity)
    {
        Id = entity.Id;
        Fullname = entity.Fullname;
        DocNumber = entity.DocNumber;
        GuardianId = entity.GuardianId;
        DateOfBirth = entity.DateOfBirth;
        Status = entity.Status;
        Street = entity.Address?.Street;
        City = entity.Address?.City;
        Province = entity.Address?.Province;
        ZipCode = entity.Address?.ZipCode;
    }
}