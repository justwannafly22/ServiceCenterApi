using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepairApi.Domain;
using RepairApi.Factories;
using RepairApi.Repository.Entities;
using RepairApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepairApi.Repository
{
    public class RepairRepository : IRepairRepository
    {
        private readonly RepositoryDbContext _context;
        private readonly IRepositoryFactory _factory;
        private readonly ILogger<RepairRepository> _logger;

        public RepairRepository(RepositoryDbContext context, IRepositoryFactory factory, ILogger<RepairRepository> logger)
        {
            _context = context;
            _factory = factory;
            _logger = logger;
        }

        public async Task<RepairDomainModel> CreateAsync(RepairDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = _factory.ToEntity(model);
            await _context.AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogDebug($"The repair: {entity} was successfully created.");

            return _factory.ToDomain(entity);
        }

        public async Task DeleteAsync(RepairDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetRepairByExpression(r => r.Id.Equals(model.Id))
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            _context.Remove(entity);

            _logger.LogDebug($"The repair: {entity} was successfully deleted.");

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<RepairDomainModel>> GetAllAsync()
        {
            var entities = await GetAllRepairs()
                                .Include(r => r.RepairInfo)
                                    .ThenInclude(r => r.Status)
                                .Select(r => _factory.ToDomain(r))
                                .ToListAsync()
                                .ConfigureAwait(false);

            _logger.LogDebug($"The repair table was triggered.");

            return entities;
        }

        public async Task<RepairDomainModel> GetByIdAsync(RepairDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetRepairByExpression(r => r.Id.Equals(model.Id))
                              .Include(r => r.RepairInfo)
                                .ThenInclude(r => r.Status)
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            _logger.LogDebug($"The repair table was triggered.");

            return _factory.ToDomain(entity);
        }
        
        public async Task<List<RepairDomainModel>> GetAllByClientIdAsync(RepairDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entities = await GetRepairByExpression(r => r.ClientId.Equals(model.ClientId))
                              .Include(r => r.RepairInfo)
                                .ThenInclude(r => r.Status)
                              .Select(r => _factory.ToDomain(r))
                              .ToListAsync()
                              .ConfigureAwait(false);

            _logger.LogDebug($"The repair table was triggered.");

            return entities;
        }
        
        public async Task<List<RepairDomainModel>> GetAllByMasterIdAsync(RepairDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entities = await GetRepairByExpression(r => r.MasterId.Equals(model.MasterId))
                              .Include(r => r.RepairInfo)
                                .ThenInclude(r => r.Status)
                              .Select(r => _factory.ToDomain(r))
                              .ToListAsync()
                              .ConfigureAwait(false);

            _logger.LogDebug($"The repair table was triggered.");

            return entities;
        }

        public async Task<RepairDomainModel> UpdateAsync(RepairDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetRepairByExpression(r => r.Id.Equals(model.Id))
                              .Include(r => r.RepairInfo)
                                .ThenInclude(r => r.Status)
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            entity.Name = model.Name;
            entity.RepairInfo.Date = model.Date;
            entity.RepairInfo.AdvancedInfo = model.AdvancedInfo;
            entity.RepairInfo.Status.StatusInfo = model.Status;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogDebug($"The repair: {entity} was successfully updated.");

            return _factory.ToDomain(entity);
        }

        private IQueryable<Repair> GetAllRepairs() =>
            _context.Set<Repair>();

        private IQueryable<Repair> GetRepairByExpression(Expression<Func<Repair, bool>> expression) =>
            _context.Set<Repair>()
                    .Where(expression);
    }
}
