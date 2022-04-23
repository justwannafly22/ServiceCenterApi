using Microsoft.EntityFrameworkCore;

namespace RepairApi.Repository.Entities
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepairInfo>()
                .HasOne(r => r.Repair)
                .WithOne(r => r.RepairInfo)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<RepairInfo> RepairsInfo { get; set; }
    }
}
