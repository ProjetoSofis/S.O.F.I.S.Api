using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Interfaces
{
    public interface IReportRepository
    {
        Task AddAsync(Report report);
        Task<Report?> GetByIdAsync(Guid id);
        Task<IEnumerable<Report>> GetAllAsync();
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Report report);
    }
}
