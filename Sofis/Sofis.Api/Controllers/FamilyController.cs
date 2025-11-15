using Microsoft.AspNetCore.Mvc;
using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.FamilyDtos;

namespace Sofis.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FamilyController : ControllerBase
    {
        // Vinicius: Implement the FamilyController methods here
        private readonly IFamilyService _familyService;
        private readonly ILogger<FamilyController> _logger;
        public FamilyController(IFamilyService familyService, ILogger<FamilyController> logger)
        {
            this._familyService = familyService;
            this._logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFamilies()
        {
            try
            {
                var families = await _familyService.GetAllAsync();
                return Ok(families);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving families.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }
        [HttpGet]
        [Route("cpf/{cpf}")]
        public async Task<IActionResult> GetFamilyByCpf(string cpf)
        {
            try
            {
                var family = await _familyService.GetByCpf(cpf);
                if (family == null)
                {
                    return NotFound();
                }
                return Ok(family);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving family by CPF.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFamilyById(Guid id)
        {
            try
            {
                var family = await _familyService.GetByIdAsync(id);
                if (family == null)
                {
                    return NotFound();
                }
                return Ok(family);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving family by ID.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> RegisterFamily([FromBody] CreateFamilyDto dto)
        {
            try
            {
                var family = await _familyService.RegisterFamilyAsync(dto);
                return CreatedAtAction(nameof(GetFamilyById), new { id = family.Id }, family);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering family.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFamily([FromBody] UpdateFamilyDto dto)
        {
            try
            {
                var family = await _familyService.UpdateFamilyAsync(dto);
                return Ok(family);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating family.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFamily(Guid id)
        {
            try
            {
                await _familyService.DeleteFamilyAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting family.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }
    }
}
