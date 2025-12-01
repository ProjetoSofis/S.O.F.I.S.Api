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
            var guardian = await GetByIdAsync(id);
            if (guardian != null)
            {
                _context.Guardians.Remove(guardian);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Guardian?> GetByCpfAsync(string cpf)
        {
            return await _context.Guardians
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Cpf == cpf);
        }

        public Task<Guardian?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
