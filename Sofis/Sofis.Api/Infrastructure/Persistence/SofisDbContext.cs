using Microsoft.EntityFrameworkCore;
using Sofis.Api.Domain.Entities;
namespace Sofis.Api.Infrastructure.Persistence;

public class SofisDbContext : DbContext
{
    public SofisDbContext(DbContextOptions<SofisDbContext> options) : base(options) { }
    public DbSet<Child> Childs { get; set; }
    public DbSet<Registry> Registros { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Annotation> Annotations { get; set; }
    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SofisDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}
