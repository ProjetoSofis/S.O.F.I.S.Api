using Microsoft.EntityFrameworkCore;
using Sofis.Api.Domain.Entities;
namespace Sofis.Api.Infrastructure;

public class SofisDbContext : DbContext
{
    public SofisDbContext(DbContextOptions<SofisDbContext> options) : base(options) { }
    public DbSet<Child> Child { get; set; }
    public DbSet<Report> Registros { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SofisDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}
