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
            return await _context.Childs
                .Include(c => c.Annotations)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<IEnumerable<Child>> GetAllAsync()
        {
            return await _context.Childs.ToListAsync();
        }
        public async Task AddAsync(Child child)
        {
            await _context.Childs.AddAsync(child);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Child child)
        {
            _context.Childs.Update(child);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var child = await GetByIdAsync(id);
            if (child != null)
            {
                _context.Childs.Remove(child);
                await _context.SaveChangesAsync();
            }
        }
    }
}
