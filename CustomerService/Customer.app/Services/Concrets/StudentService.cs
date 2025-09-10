using Customer.app.DTOs;
using Customer.app.Mappings;
using Customer.app.Services.Interfaces;
using Customer.app.UseCases.Commands;
using Customer.domain.Entities;
using Customer.domain.Interfaces;
using Customer.domain.ValueObjects;

namespace Customer.app.Services.Concrets;

public class StudentService(IUnitOfWork uow) : IStudentService
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<StudentDto> CreateStudentAsync(CreateStudentCommand command, CancellationToken cancellationToken = default)
    {
        AddressVO? address = null;
        if (!string.IsNullOrWhiteSpace(command.Street) &&
            !string.IsNullOrWhiteSpace(command.City) &&
            !string.IsNullOrWhiteSpace(command.Province) &&
            !string.IsNullOrWhiteSpace(command.ZipCode))
        {
            address = AddressVO.Create(command.Street, command.City, command.Province, command.ZipCode);
        }

        var student = new Student(
            command.Fullname,
            command.DocNumber,
            command.GuardianId,
            command.DateOfBirth,
            address
        );

        await _uow.Students.AddAsync(student, cancellationToken);
        await _uow.CommitAsync(cancellationToken);

        return StudentMapper.ToDto(student);
    }

    public async Task<StudentDto?> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var student = await _uow.Students.GetByIdAsync(id, cancellationToken);

        return student is null ? null : StudentMapper.ToDto(student);
    }

    public async Task UpdateStudentAddressAsync(Guid studentId, AddressVO newAddress, CancellationToken cancellationToken = default)
    {
        var student = await _uow.Students.GetByIdAsync(studentId, cancellationToken)
                      ?? throw new KeyNotFoundException("Estudante não encontrado.");

        student.UpdateAddress(newAddress);
        await _uow.Students.UpdateAsync(student, cancellationToken);
        await _uow.CommitAsync(cancellationToken);
    }

    public async Task DeactivateStudentAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        var student = await _uow.Students.GetByIdAsync(studentId, cancellationToken)
            ?? throw new KeyNotFoundException("Estudante não encontrado.");

        student.Deactivate();
        await _uow.Students.UpdateAsync(student, cancellationToken);
        await _uow.CommitAsync(cancellationToken);
    }
}
