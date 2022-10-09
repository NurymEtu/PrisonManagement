using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrisonManagementWebApp.Models;

namespace PrisonManagementWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Prison> Prisons { get; set; }
        public DbSet<Prisoner> Prisoners { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Guard> Guards { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
    }
}