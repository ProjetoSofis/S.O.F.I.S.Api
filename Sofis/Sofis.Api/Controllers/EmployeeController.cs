using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.EmployeeDtos;

namespace Sofis.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            this._employeeService = employeeService;
            this._logger = logger;
        }
        //Vinicius : Adicionei tratamento de exceções para melhorar a robustez da API.
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving employees.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }
        [HttpGet]
        [Route("cpf/{cpf}")]
        public async Task<IActionResult> GetEmployeeByCpf(string cpf)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByCpf(cpf);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving employee by CPF.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }
        [HttpGet]
        [Route("name/{name}")]
        public async Task<IActionResult> GetEmployeesByName(string name)
        {
            try
            {
                var employees = await _employeeService.GetEmployeesByName(name);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving employees by name.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving employee by ID.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }
        [HttpGet]
        [Route("email/{email}")]
        public async Task<IActionResult> GetEmployeeByEmail(string email)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByEmail(email);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving employee by email.");
                return StatusCode(500, new
                {
                    error = "Internal server error.",
                    details = ex.Message
                });
            }
        }
        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> AddEmployee([FromBody] CreateEmployeeDto dto)
        {
            try
            {
                var created = await _employeeService.CreateEmployee(dto);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = created.Id }, created);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new
                {
                    error = "Erro ao salvar o funcionário no banco de dados.",
                    details = ex.InnerException?.Message ?? ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ao criar funcionário.");
                return StatusCode(500, new
                {
                    error = "Erro interno do servidor",
                    details = ex.Message
                });
            }
        }
        [HttpPut]
        [Route("atualizar/{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeDto dto)
        {
            try
            {
                var updated = await _employeeService.UpdateEmployee(id, dto);
                if (updated == null)
                {
                    return NotFound();
                }
                return Ok(updated);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new
                {
                    error = "Erro ao atualizar o funcionário no banco de dados.",
                    details = ex.InnerException?.Message ?? ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ao atualizar funcionário.");
                return StatusCode(500, new
                {
                    error = "Erro interno do servidor",
                    details = ex.Message
                });
            }
        }
        [HttpDelete]
        [Route("deletar/{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                await _employeeService.DeleteEmployee(id);
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new
                {
                    error = "Erro ao deletar o funcionário no banco de dados.",
                    details = ex.InnerException?.Message ?? ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ao deletar funcionário.");
                return StatusCode(500, new
                {
                    error = "Erro interno do servidor",
                    details = ex.Message
                });
            }
        }

        
    }
}
