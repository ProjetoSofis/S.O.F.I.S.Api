using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Interfaces
{
    public interface IAnnotationRepository
    {
        Task AddAsync(Annotation annotation);
        Task<Annotation?> GetByIdAsync(Guid id);
        Task<IEnumerable<Annotation>> GetAllAsync();
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Annotation annotation);
    }
}
