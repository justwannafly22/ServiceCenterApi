using Microsoft.EntityFrameworkCore;

namespace ReplacedPartApi.Repository.Entities
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<ReplacedPart> ReplacedParts { get; set; }
    }
}
