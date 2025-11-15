using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee);
        Task<Employee?> GetByIdAsync(Guid id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(Guid id);
        Task<Employee?> GetByEmailAsync(string email);
        Task<IEnumerable<Employee>> GetByNameAsync(string name);
        Task<Employee?> GetByCpfAsync(string cpf);
    }
}
