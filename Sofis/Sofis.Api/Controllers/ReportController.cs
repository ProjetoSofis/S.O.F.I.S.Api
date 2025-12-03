using Microsoft.AspNetCore.Mvc;
using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.ReportDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sofis.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly ILogger<ReportController> _logger;

        public ReportController(IReportService reportService, ILogger<ReportController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] CreateReportDto dto)
        {
            try
            {
                var createdReport = await _reportService.CreateReportAsync(dto);
                return CreatedAtAction(nameof(GetReportById), new { id = createdReport.Id }, createdReport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating a new report.");
                return StatusCode(500, new { error = "Internal server error.", details = ex.Message });
            }
        }

        [HttpGet("child/{childId:guid}")]
        public async Task<IActionResult> GetReportsByChildId(Guid childId)
        {
            try
            {
                var reports = await _reportService.GetReportsByChildIdAsync(childId);
                return Ok(reports);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving reports for child with ID {childId}.");
                return StatusCode(500, new { error = "Internal server error.", details = ex.Message });
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetReportById(Guid id)
        {
            try
            {
                var report = await _reportService.GetReportByIdAsync(id);
                if (report == null)
                {
                    return NotFound();
                }
                return Ok(report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving report with ID {id}.");
                return StatusCode(500, new { error = "Internal server error.", details = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteReport(Guid id)
        {
            try
            {
                await _reportService.DeleteReportAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting report with ID {id}.");
                return StatusCode(500, new { error = "Internal server error.", details = ex.Message });
            }
        }
    }
}
