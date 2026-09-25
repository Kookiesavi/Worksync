using Microsoft.EntityFrameworkCore;
using WorkSync.Domain.Entities;

namespace WorkSync.Infrastructure.Data
{
    public class WorkSyncDbContext : DbContext
    {
        public WorkSyncDbContext(DbContextOptions<WorkSyncDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(a => a.Salary).HasPrecision(18, 2);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Team)
                .WithMany(t => t.Members)
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Team>()
       .ToTable("Team");

            base.OnModelCreating(modelBuilder);
        }
    }
}
