using Microsoft.AspNetCore.Mvc;
using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.GuardianDtos;

namespace Sofis.Api.Controllers
{
    public class GuardianController : ControllerBase
    {
        private readonly IGuardianService _guardianService;
        private readonly ILogger<GuardianController> _logger;
        public GuardianController(IGuardianService guardianService, ILogger<GuardianController> logger)
        {
            this._guardianService = guardianService;
            this._logger = logger;
        }
        [HttpPost]
        [Route("adicionarGuardiao")]
        public async Task<IActionResult> CreateGuardian([FromBody] CreateGuardianDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdGuardian = await _guardianService.CreateGuardianAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = createdGuardian.Id }, createdGuardian);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating guardian.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var guardian = await _guardianService.GetGuardianByIdAsync(id);
                if (guardian == null)
                {
                    return NotFound();
                }
                return Ok(guardian);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving guardian by ID.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("buscar-todos")]
        public async Task<IActionResult> GetAllGuardians()
        {
            try
            {
                var guardians = await _guardianService.GetAllGuardiansAsync();
                return Ok(guardians);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving guardians.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }
    }
}
