using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Interfaces
{
    public interface IFamilyRepository
    {
        Task<ICollection<Family>> GetAllAsync();
        Task<Family?> GetByIdAsync(Guid id);
        Task<Family> AddAsync(Family family);
        Task UpdateFamilyAsync(Family family);
        Task DeleteFamilyAsync(Guid id);

    }
}
