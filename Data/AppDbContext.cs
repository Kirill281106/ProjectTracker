using Microsoft.EntityFrameworkCore;
using ProjectTracker.Models;
using System.Data.Common;

namespace ProjectTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().HasMany(p => p.Tasks).WithOne(p => p.Project);
        }
    }
}