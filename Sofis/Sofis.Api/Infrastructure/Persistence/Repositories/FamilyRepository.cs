using Microsoft.EntityFrameworkCore;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Infrastructure.Persistence.Repositories
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly SofisDbContext _context;
        public FamilyRepository(SofisDbContext context)
        {
            _context = context;
        }
        public async Task AddFamilyAsync(Family family)
        {
            await _context.Family.AddAsync(family);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFamilyAsync(Guid id)
        {
            var familyExist = await GetByIdAsync(id);
            if (familyExist != null)
            {
                _context.Remove(familyExist);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Family>> GetAllAsync()
        {
            return await _context.Family.ToListAsync();
        }

        public async Task<Family?> GetByCpfAsync(string cpf)
        {
            return await _context.Family
                .FirstOrDefaultAsync(f => f.Cpf == cpf);
        }

        public async Task<Family?> GetByIdAsync(Guid id)
        {
            return await _context.Family
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task UpdateFamilyAsync(Family family)
        {
            var familyExist = await GetByIdAsync(family.Id);
            if (familyExist != null)
            {
                _context.Family.Update(family);
                await _context.SaveChangesAsync();
            }
        }
    }
}
