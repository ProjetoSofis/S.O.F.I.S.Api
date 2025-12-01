using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.ReportDtos;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly ILogger<ReportService> _logger;
        private readonly IReportRepository _reportRepository;
        public ReportService(ILogger<ReportService> logger, IReportRepository reportRepository)
        {
            _logger = logger;
            _reportRepository = reportRepository;
        }

        public async Task<ReportDto> CreateReportAsync(CreateReportDto dto)
        {
            var existingReport = _reportRepository.GetByIdAsync(dto.Id);
            if (existingReport != null)
            {
                throw new Exception($"Relatório com id {dto.Id} já existe.");
            }
            var report = new Report
            {
                EmployeeId = dto.EmployeeId,
                ChildId = dto.ChildId,
                Title = dto.Title,
                Description = dto.Description
            };
            await _reportRepository.AddAsync(report);
            return MapToDto(report);
        }

        public async Task DeleteReportAsync(Guid id)
        {
            var report = _reportRepository.GetByIdAsync(id);
            if (report == null)
            {
                throw new Exception("Relatório não encontrado");
            }
            await _reportRepository.DeleteAsync(id);
        }

        public async Task<ReportDto?> GetReportByIdAsync(Guid id)
        {
            var report = await _reportRepository.GetByIdAsync(id);
            if (report == null)
            {
                throw new Exception("Relatório não encontrado");
            }
            return MapToDto(report);
        }

        public async Task<IEnumerable<ReportDto>> GetReportsByChildIdAsync(Guid childId)
        {
            var reports = await _reportRepository.GetAllByChildIdAsync(childId);
            return reports.Select(MapToDto);
        }

        private ReportDto MapToDto(Report dto)
        {
            return new ReportDto
            {
                EmployeeId = dto.EmployeeId,
                ChildId = dto.ChildId,
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };
        }
    }
}
