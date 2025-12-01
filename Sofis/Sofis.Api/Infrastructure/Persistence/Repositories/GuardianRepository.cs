using Microsoft.EntityFrameworkCore;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Infrastructure.Persistence.Repositories
{
    public class GuardianRepository : IGuardianRepository
    {
        private readonly SofisDbContext _context;
        public GuardianRepository(SofisDbContext context)
        {
            _context = context;
        }
        public async Task<Guardian> AddAsync(Guardian guardian)
        {
            await _context.Guardians.AddAsync(guardian);
            await _context.SaveChangesAsync();
            return guardian;
        }
        public async Task DeleteAsync(Guid id)
        {
            var guardian = await _context.Guardians.FindAsync(id);
            if (guardian != null)
            {
                _context.Guardians.Remove(guardian);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Guardian>> GetAllAsync()
        {
            return await _context.Guardians
                .Include(g => g.Family)
                .ToListAsync();
        }

        public Task<Guardian?> GetByCpfAsync(string cpf)
        {
            return _context.Guardians
                .Include(g => g.Family)
                .FirstOrDefaultAsync(g => g.Cpf == cpf);
        }

        public async Task<Guardian?> GetByIdAsync(Guid id)
        {
            return await _context.Guardians
                .Include(g => g.Family)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task UpdateAsync(Guardian guardian)
        {
            _context.Guardians.Update(guardian);
            await _context.SaveChangesAsync();
        }
    }
}
