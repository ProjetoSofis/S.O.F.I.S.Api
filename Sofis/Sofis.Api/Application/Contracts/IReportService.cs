using Sofis.Api.Application.Dtos.ReportDtos;

namespace Sofis.Api.Application.Contracts
{
    public interface IReportService
    {
        Task<ReportDto> CreateReportAsync(CreateReportDto dto);
        Task<IEnumerable<ReportDto>> GetReportsByChildIdAsync(Guid childId);
        Task<ReportDto?> GetReportByIdAsync(Guid id);
        Task DeleteReportAsync(Guid id);
    }
}
