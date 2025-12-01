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
        public async Task<Family> AddAsync(Family family)
        {
            _context.Family.AddAsync(family);
            await _context.SaveChangesAsync();
            return family;
        }

        public async Task DeleteFamilyAsync(Guid id)
        {
            var family = await _context.Family.FindAsync(id);
            if (family != null)
            {
                _context.Remove(family);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Family>> GetAllAsync()
        {
            return await _context.Family
                .Include(f => f.Guardians)
                .Include(f => f.RelationedChildren)
                .ToListAsync();
        }

        public async Task<Family?> GetByIdAsync(Guid id)
        {
            return await _context.Family.FindAsync(id);
        }

        public async Task<Family?> GetFamilyDetailsAsync(Guid id)
        {
            return await _context.Family
                .Include(f => f.Guardians)
                .Include(f => f.RelationedChildren)
                .FirstOrDefaultAsync(f => f.Id == id);
        }


        public async Task UpdateFamilyAsync(Family family)
        {
            _context.Family.Update(family);
            await _context.SaveChangesAsync();
        }
    }
}
