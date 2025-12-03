using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Interfaces
{
    public interface IReportRepository
    {
        Task<Report> AddAsync(Report report);
        Task<Report?> GetByIdAsync(Guid id);
        Task<IEnumerable<Report>> GetAllByChildIdAsync(Guid childId);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Report report);
    }
}
