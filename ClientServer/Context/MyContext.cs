using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context;
public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }

    // Introduce the model to the database that eventually become an entity
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Profiling> Profilings { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<University> Universities { get; set; }

    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // One University has many Educations
        modelBuilder.Entity<University>()
                    .HasMany(u => u.Educations)
                    .WithOne(e => e.University)
                    .HasForeignKey(e => e.UniversityId)
                    .OnDelete(DeleteBehavior.Restrict);

        // One Education has one Profiling
        modelBuilder.Entity<Education>()
                    .HasOne(e => e.Profiling)
                    .WithOne(p => p.Education)
                    .HasForeignKey<Profiling>(p => p.EducationId)
                    .OnDelete(DeleteBehavior.Restrict);

        // One Employee has one profiling
        modelBuilder.Entity<Employee>()
                    .HasOne(e => e.Profiling)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Profiling>(p => p.EmployeeNIK)
                    .OnDelete(DeleteBehavior.Restrict);

        // One Employee has one account
        modelBuilder.Entity<Employee>()
                    .HasOne(e => e.Account)
                    .WithOne(a => a.Employee)
                    .HasForeignKey<Account>(a => a.EmployeeNIK)
                    .OnDelete(DeleteBehavior.Restrict);

        // One Role has many AccountRoles
        modelBuilder.Entity<Role>()
                    .HasMany(r => r.AccountRole)
                    .WithOne(a => a.Role)
                    .HasForeignKey(a => a.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

        // One Account has many AccountRoles
        modelBuilder.Entity<Account>()
                    .HasMany(a => a.AccountRole)
                    .WithOne(a => a.Account)
                    .HasForeignKey(a => a.AccountNIK)
                    .OnDelete(DeleteBehavior.Restrict);
    }
}

