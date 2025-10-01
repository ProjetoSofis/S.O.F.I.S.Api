
using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Interfaces
{
    public interface IRegistryRepository
    {
        Task AddAsync( Registry registry);
        Task<Registry?> GetByIdAsync(Guid id);
        Task<IEnumerable<Registry>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
