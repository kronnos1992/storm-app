using Customer.app.DTOs;
using Customer.app.UseCases.Commands;
using Customer.domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.app.Services.Interfaces;

public interface IGuardianService
{
    // Create a new guardian
    Task<GuardianDto> CreateGuardianAsync(CreateGuardianCommand command, CancellationToken cancellationToken = default);

    // Retrieve guardians
    Task<GuardianDto?> GetGuardianByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<GuardianDto>> GetAllGuardiansAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GuardianDto>> GetGuardiansByStudentIdAsync(Guid studentId, CancellationToken cancellationToken = default);

    // Update operations
    Task UpdateGuardianContactInfoAsync(Guid guardianId, ContactVO contactInfo, CancellationToken cancellationToken = default);
    Task UpdateGuardianAddressAsync(Guid guardianId, AddressVO newAddress, CancellationToken cancellationToken = default);

    // Status management
    Task ActivateGuardianAsync(Guid guardianId, CancellationToken cancellationToken = default);
    Task DeactivateGuardianAsync(Guid guardianId, CancellationToken cancellationToken = default);

    // Student-guardian relationship management
    Task AddStudentToGuardianAsync(Guid guardianId, Guid studentId, CancellationToken cancellationToken = default);
    Task RemoveStudentFromGuardianAsync(Guid guardianId, Guid studentId, CancellationToken cancellationToken = default);

    // Verification and validation
    Task<bool> VerifyGuardianRelationshipAsync(Guid guardianId, Guid studentId, CancellationToken cancellationToken = default);
    Task<bool> IsGuardianActiveAsync(Guid guardianId, CancellationToken cancellationToken = default);
}