using Sofis.Api.Domain.Entities;
namespace Sofis.Api.Application.Interfaces
{
    public interface IChildRepository
    {
        Task AddAsync(Child Child);
        Task<Child?> GetByIdAsync(Guid id);
        Task<Child?> GetByCpfAsync(string cpf);
        Task<IEnumerable<Child>> GetByNameAsync(string name);
        Task<IEnumerable<Child>> GetAllAsync();
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Child Child);
    }
}
