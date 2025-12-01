using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Interfaces
{
    public interface IGuardianRepository
    {
        Task<Guardian> AddAsync(Guardian guardian);
        Task<Guardian?> GetByIdAsync(Guid id);
        Task<Guardian?> GetByCpfAsync(string cpf);
        Task DeleteAsync(Guid id);
    }
}
