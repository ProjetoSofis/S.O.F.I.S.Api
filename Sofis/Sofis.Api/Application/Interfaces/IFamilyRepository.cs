using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Interfaces
{
    public interface IFamilyRepository
    {
        Task<IEnumerable<Family>> GetAllAsync();
        Task<Family?> GetByIdAsync(Guid id);
        Task<Family?> GetByCpfAsync(string cpf);
        Task AddFamilyAsync(Family family);
        Task UpdateFamilyAsync(Family family);
        Task DeleteFamilyAsync(Guid id);

    }
}
