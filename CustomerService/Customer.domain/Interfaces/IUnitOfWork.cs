namespace Customer.domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IStudentRepository StudentRepository { get; }
    IGuardianRepository GuardianRepository { get; }

    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
