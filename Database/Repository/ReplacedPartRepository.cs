using Database.Domain;
using Database.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database
{
    public class ReplacedPartRepository : IReplacedPartRepository
    {
        private readonly RepositoryDbContext _context;
        private readonly ILogger<ReplacedPartRepository> _logger;

        public ReplacedPartRepository(RepositoryDbContext context, ILogger<ReplacedPartRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ReplacedPartDomainModel> CreateAsync(ReplacedPartDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = model.ToEntity();
            await _context.AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation($"The replaced part was successfully created.");

            return entity?.ToDomain();
        }

        public async Task DeleteAsync(ReplacedPartDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetByExpression(r => r.Id.Equals(model.Id))
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            _context.Set<ReplacedPart>().Remove(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation($"The replaced part was successfully deleted.");
        }

        public async Task<List<ReplacedPartDomainModel>> GetAllByProductIdAsync(Guid productId)
        {
            var entities = await GetAll().Where(r => r.ProductId.Equals(productId))
                                         .Select(r => r.ToDomain())
                                         .ToListAsync()
                                         .ConfigureAwait(false);

            _logger.LogInformation($"The ReplacedPart table was triggered");

            return entities;
        }
        
        public async Task<List<ReplacedPartDomainModel>> GetAllByRepairIdAsync(Guid repairId)
        {
            var entities = await GetAll().Where(r => r.RepairId.Equals(repairId))
                                         .Select(r => r.ToDomain())
                                         .ToListAsync()
                                         .ConfigureAwait(false);

            _logger.LogInformation($"The ReplacedPart table was triggered");

            return entities;
        }

        public async Task<ReplacedPartDomainModel> GetByIdAsync(ReplacedPartDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetByExpression(r => r.Id.Equals(model.Id))
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            _logger.LogInformation($"The ReplacedPart table was triggered");

            return entity?.ToDomain();
        }

        public async Task<ReplacedPartDomainModel> UpdateAsync(ReplacedPartDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetByExpression(r => r.Id.Equals(model.Id))
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Count = model.Count;
            entity.AdvancedInfo = model.AdvancedInfo;

            _context.Update(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation($"The replaced part was successfully updated.");

            return entity?.ToDomain();
        }

        private IQueryable<ReplacedPart> GetAll() =>
            _context.Set<ReplacedPart>();

        private IQueryable<ReplacedPart> GetByExpression(Expression<Func<ReplacedPart, bool>> expression) =>
            _context.Set<ReplacedPart>()
                    .Where(expression);
    }
}
