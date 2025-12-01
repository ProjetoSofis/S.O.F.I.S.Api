using Sofis.Api.Application.Dtos.EmployeeDtos;
using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        Task<EmployeeDto?> GetEmployeeById(Guid id);
        Task<EmployeeDto?> GetEmployeeByCpf(string cpf);
        Task<IEnumerable<EmployeeDto>> GetEmployeesByName(string name);
        Task<EmployeeDto?> GetEmployeeByEmail(string email);
        Task<EmployeeDto> CreateEmployee(CreateEmployeeDto employee);
        Task<EmployeeDto?> UpdateEmployee(Guid id, UpdateEmployeeDto employee);
        Task DeleteEmployee(Guid id);
    }
}
