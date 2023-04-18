using Ferretly.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ferretly.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Activity>()
        .HasKey(k => new { k.RoleId, k.ProjectId, k.EmployeeId, k.TypeId });
      builder.Entity<Project>().HasIndex(p => p.Name).IsUnique();
      builder.Entity<Role>().HasIndex(p => p.Name).IsUnique();
      builder.Entity<ActivityType>().HasIndex(p => p.Name).IsUnique();
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityType> ActivityTypes { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Employee> Employees { get; set; }

  }
}
