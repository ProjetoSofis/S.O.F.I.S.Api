using Sofis.Api.Domain.Entities;
namespace Sofis.Api.Application.Interfaces
{
    public interface IChildRepositoy
    {
        Task AddAsync(Child Child);
        Task<Child?> GetByIdAsync(Guid id);
        Task<IEnumerable<Child>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
