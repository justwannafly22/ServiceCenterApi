using Microsoft.EntityFrameworkCore;

namespace Database
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

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<ReplacedPart> ReplacedParts { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<RepairInfo> RepairsInfo { get; set; }
    }
}
