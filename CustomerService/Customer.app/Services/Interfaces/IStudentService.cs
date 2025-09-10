using Customer.app.DTOs;
using Customer.app.UseCases.Commands;
using Customer.domain.ValueObjects;

namespace Customer.app.Services.Interfaces;


public interface IStudentService
{
    Task<StudentDto> CreateStudentAsync(CreateStudentCommand command, CancellationToken cancellationToken = default);
    Task<StudentDto?> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateStudentAddressAsync(Guid studentId, AddressVO newAddress, CancellationToken cancellationToken = default);
    Task DeactivateStudentAsync(Guid studentId, CancellationToken cancellationToken = default);
}
