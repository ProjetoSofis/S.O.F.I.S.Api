using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.EmployeeDtos;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;
using System.Diagnostics;

namespace Sofis.Api.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordService _passwordService;
        public EmployeeService(IEmployeeRepository employeeRepository, IPasswordService passwordService)
        {
            _employeeRepository = employeeRepository;
            _passwordService = passwordService;
        }
        public async Task<EmployeeDto> CreateEmployee(CreateEmployeeDto dto)
        {
            var existingEmployee = await _employeeRepository.GetByEmailAsync(dto.Email);
            if (existingEmployee != null)
            {
                throw new Exception("Já existe um funcionário cadastrado com esse email.");
            };
            // Vinicius: Cria o hash e o sAalt da senha fornecida
            _passwordService.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Cpf = dto.Cpf,
                Role = dto.Role,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await  _employeeRepository.AddAsync(employee);
            return MapToDto(employee);

        }

        public async Task DeleteEmployee(Guid id)
        {
            // Lógica para deletar o funcionário
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new Exception("Funcionário não encontrado.");
            }
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Select(MapToDto);
        }

        public async Task<EmployeeDto?> GetEmployeeByCpf(string cpf)
        {
            var employee = await _employeeRepository.GetByCpfAsync(cpf);
            if (employee == null)
            {
               throw new Exception("Funcionário não encontrado.");
            }
            return MapToDto(employee);
        }

        public async Task<EmployeeDto?> GetEmployeeByEmail(string email)
        {
            var employee = await _employeeRepository.GetByEmailAsync(email);
            if (employee == null)
            {
                throw new Exception("Funcionário não encontrado.");
            }
            return MapToDto(employee);
        }

        public async Task<EmployeeDto?> GetEmployeeById(Guid id)
        {
            var employee = await  _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new Exception("Funcionário não encontrado.");
            }
            return MapToDto(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByName(string name)
        {
            var employees = await _employeeRepository.GetByNameAsync(name);
            return employees.Select(MapToDto);
        }

        public async Task<EmployeeDto?> UpdateEmployee(Guid id, UpdateEmployeeDto dto)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                throw new Exception("Funcionário não encontrado.");
            }
            existingEmployee.Name = dto.Name;
            existingEmployee.Email = dto.Email;
            existingEmployee.Phone = dto.Phone;
            existingEmployee.Cpf = dto.Cpf;
            existingEmployee.Role = dto.Role;
            existingEmployee.IsActive = dto.IsActive;
            existingEmployee.IsTwoFactorEnabled = dto.IsTwoFactorEnabled;

            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                _passwordService.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            }
            await _employeeRepository.UpdateAsync(existingEmployee);
            return MapToDto(existingEmployee);
        }
        private EmployeeDto MapToDto(Employee e) =>
            new EmployeeDto
            {
            Id = e.Id,
            Name = e.Name,
            Email = e.Email,
            Phone = e.Phone,
            Cpf = e.Cpf,
            Role = e.Role,
            IsActive = e.IsActive,
            CreatedAt = e.CreatedAt
            };
    }
}
