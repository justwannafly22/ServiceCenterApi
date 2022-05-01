using Microsoft.Extensions.Logging;

namespace MasterApi.Repository
{
    public class MasterRepository : IMasterRepository
    {
        private readonly RepositoryDbContext _context;
        // Factory.
        private readonly ILogger<MasterRepository> _logger;

        public MasterRepository(RepositoryDbContext context, ILogger<MasterRepository> logger)
        {
            _context = context;
            // Factory.
            _logger = logger;
        }


    }
}
