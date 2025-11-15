using Microsoft.EntityFrameworkCore;
using Sofis.Api.Domain.Entities;
namespace Sofis.Api.Infrastructure;

public class SofisDbContext : DbContext
{
    public SofisDbContext(DbContextOptions<SofisDbContext> options) : base(options) { }
    public DbSet<Child> Child { get; set; }
    public DbSet<Family> Family { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SofisDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Child>(entity =>
        {
            // Configura a relação "Um-para-Muitos"
            entity.HasMany(c => c.Reports)
                  .WithOne(r => r.Child)
                  .HasForeignKey(r => r.ChildId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }

}
