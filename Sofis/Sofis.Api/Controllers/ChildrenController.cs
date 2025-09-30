using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos;

namespace Sofis.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ChildrenController : ControllerBase
    {
        private readonly IChildService _childService;
        private readonly ILogger<ChildrenController> _logger;

        public ChildrenController(IChildService childService, ILogger<ChildrenController> logger)
        {
            _childService = childService;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateChildDto dto)
        {
            var created = await _childService.RegisterChildAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _childService.GetAllAsync();
            return Ok(list);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var child = await _childService.GetByIdAsync(id);
            if (child == null)
            {
                return NotFound();
            }
            return Ok(child);
        }
    }
}
