using Microsoft.EntityFrameworkCore;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Infrastructure.Persistence.Repositories
{
    public class ChildRepository : IChildRepository
    {
        private readonly SofisDbContext _context;

        public ChildRepository(SofisDbContext context)
        {
            _context = context;

        }
        public async Task<Child?> GetByIdAsync(Guid id)
        {
            return await _context.Child
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<IEnumerable<Child>> GetAllAsync()
        {
            return await _context.Child.ToListAsync();
        }
        public async Task AddAsync(Child child)
        {
            await _context.Child.AddAsync(child);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Child child)
        {
            _context.Child.Update(child);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var child = await GetByIdAsync(id);
            if (child != null)
            {
                _context.Child.Remove(child);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Child?> GetByCpfAsync(string cpf)
        {
            return await _context.Child
                .FirstOrDefaultAsync(c => c.Cpf == cpf);
        }
        public async Task<IEnumerable<Child>> GetFamilyMembersByChildIdAsync(Guid childId)
        {
            var childWithFamily = await _context.Child
                .Include(c => c.Family)
                .ThenInclude(f => f.RelationedChildren)
                .FirstOrDefaultAsync(c => c.Id == childId);
            if (childWithFamily == null || childWithFamily.Family == null)
            {
                return Enumerable.Empty<Child>();
            }
            return childWithFamily.Family.RelationedChildren;
        }

        public async Task<IEnumerable<Child>> GetByNameAsync(string name)
        {
            return await _context.Child
                .Where(c => c.Name.Contains(name))
                .ToListAsync();
        }
    }
}
