using Microsoft.EntityFrameworkCore;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Infrastructure.Persistence.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly SofisDbContext _context;
        public ReportRepository(SofisDbContext context)
        {
            _context = context;
        }
        public async Task<Report> AddAsync(Report report)
        {
            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task DeleteAsync(Guid id)
        {
            var report = await GetByIdAsync(id);
            if (report != null)
            {
                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Report>> GetAllByChildIdAsync(Guid childId)
        {
            return await _context.Reports
                .Where(r => r.ChildId == childId)
                .ToListAsync();
        }

        public async Task<Report?> GetByIdAsync(Guid id)
        {
            return await _context.Reports
                .Include(r => r.Child)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateAsync(Report report)
        {
            var existingReport = _context.Reports.Find(report.Id);
            if (existingReport != null)
            {
                _context.Reports.Update(report);
                await _context.SaveChangesAsync();
            }
        }
    }
}
