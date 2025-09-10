using Customer.domain.Entities;

namespace Customer.domain.Interfaces;

public interface IGuardianRepository : IGenericRepository<Guardian>
{
    List<Student> GetStudentsByGuardianId(Guid guardianId);
}
