using Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database
{
    public class MasterRepository : IMasterRepository
    {
        private readonly RepositoryDbContext _context;
        private readonly IMasterRepositoryFactory _factory;
        private readonly ILogger<MasterRepository> _logger;

        public MasterRepository(RepositoryDbContext context, IMasterRepositoryFactory factory, ILogger<MasterRepository> logger)
        {
            _context = context;
            _factory = factory;
            _logger = logger;
        }

        public async Task<MasterDomainModel> CreateAsync(MasterDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = _factory.ToEntity(model);
            await _context.AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation($"The master: {entity} was successfully created.");

            return _factory.ToDomain(entity);
        }

        public async Task DeleteAsync(MasterDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetRepairByExpression(r => r.Id.Equals(model.Id))
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            _context.Remove(entity);

            _logger.LogInformation($"The master: {entity} was successfully deleted.");

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<MasterDomainModel>> GetAllAsync()
        {
            var entities = await GetAllRepairs()
                                .Select(r => _factory.ToDomain(r))
                                .ToListAsync()
                                .ConfigureAwait(false);

            _logger.LogInformation($"The master table was triggered.");

            return entities;
        }

        public async Task<MasterDomainModel> GetByIdAsync(MasterDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetRepairByExpression(r => r.Id.Equals(model.Id))
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            _logger.LogInformation($"The master table was triggered.");

            return _factory.ToDomain(entity);
        }
        
        public async Task<MasterDomainModel> GetByAttendeeIdAsync(MasterDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetRepairByExpression(r => r.AttendeeId.Equals(model.AttendeeId))
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            _logger.LogInformation($"The master table was triggered.");

            return _factory.ToDomain(entity);
        }

        public async Task<MasterDomainModel> UpdateAsync(MasterDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetRepairByExpression(r => r.Id.Equals(model.Id))
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            entity.Name = model.Name;
            entity.Surname = model.Surname;
            entity.Age = model.Age;
            entity.ContactNumber = model.ContactNumber;
            entity.Email = model.Email;
            entity.AttendeeId = model.AttendeeId;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation($"The master: {entity} was successfully updated.");

            return _factory.ToDomain(entity);
        }

        private IQueryable<Master> GetAllRepairs() =>
            _context.Set<Master>();

        private IQueryable<Master> GetRepairByExpression(Expression<Func<Master, bool>> expression) =>
            _context.Set<Master>()
                    .Where(expression);
    }
}
