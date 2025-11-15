using Microsoft.EntityFrameworkCore;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SofisDbContext _context;
        public EmployeeRepository(SofisDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var employee = await GetByIdAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByCpfAsync(string cpf)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Cpf == cpf);
        }

        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetByNameAsync(string name)
        {
            return await _context.Employees
                .Where(e => e.Name.Contains(name))
                .ToListAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            var existingEmployee = _context.Employees.Find(employee.Id);
            if (existingEmployee != null)
            {
                _context.Employees.Update(existingEmployee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
