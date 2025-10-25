﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.ChildDtos;

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
            try 
            {
                var created = await _childService.RegisterChildAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new
                {
                    error = "Erro ao salvar a criança no banco de dados.",
                    details = ex.InnerException?.Message ?? ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar a criança.");
                return StatusCode(500, new
                {
                    error = "Erro interno do servidor.",
                    details = ex.Message
                });
            }
            
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
        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            var child = await _childService.GetByCpfASync(cpf);
            if (child == null)
            {
                return NotFound();
            }
            return Ok(child);
        }

    }
}
