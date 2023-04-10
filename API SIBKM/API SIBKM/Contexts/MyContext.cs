using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profilings> Profilings { get; set; }
        public DbSet<AccountRoles> AccountRoles { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Educations> Educations { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Universities> Universities { get; set; }
    }
}
