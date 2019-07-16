using Microsoft.EntityFrameworkCore;

namespace Workers.Core
{
    public class WorkersDbContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Language> Languages { get; set; }

        public WorkersDbContext(DbContextOptions<WorkersDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
