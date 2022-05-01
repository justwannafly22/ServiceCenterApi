using Microsoft.EntityFrameworkCore;

namespace MasterApi.Repository
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Master> Masters { get; set; }
    }
}
