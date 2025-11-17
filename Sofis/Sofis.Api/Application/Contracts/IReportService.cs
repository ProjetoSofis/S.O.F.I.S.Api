using Sofis.Api.Application.Dtos.ReportDtos;

namespace Sofis.Api.Application.Contracts
{
    public interface IReportService
    {
        Task<ReportDto> CreateReport(CreateReportDto dto);
        Task<IEnumerable<ReportDto>> GetReportsByChildId(Guid childId);
        Task<ReportDto> GetReportsById(Guid id);
        Task<ReportDto?> UpdateReport(Guid id, UpdateReportDto report);
        Task DeleteReport(Guid id);
    }
}
