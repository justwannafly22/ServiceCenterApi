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
    public class ClientRepository : IClientRepository
    {
        private readonly RepositoryDbContext _context;
        private readonly IClientRepositoryFactory _factory;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(RepositoryDbContext context, IClientRepositoryFactory factory, ILogger<ClientRepository> logger)
        {
            _context = context;
            _factory = factory;
            _logger = logger;
        }

        public async Task<ClientDomainModel> CreateAsync(ClientDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = _factory.ToClient(model);
            await _context.Clients.AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation($"The client: {entity} was successfully created.");

            return _factory.ToDomain(entity);
        }

        public async Task DeleteAsync(ClientDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetClientByExpression(e => e.Id.Equals(model.Id)).SingleOrDefaultAsync().ConfigureAwait(false);

            _context.Remove(entity);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation($"The client: {entity} was successfully deleted.");
        }

        public async Task<List<ClientDomainModel>> GetAllAsync()
        {
            var entities = await GetAllClients().Select(e => _factory.ToDomain(e)).ToListAsync().ConfigureAwait(false);

            _logger.LogInformation($"The client table was triggered.");

            return entities;
        }

        public async Task<ClientDomainModel> GetByIdAsync(ClientDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetClientByExpression(e => e.Id.Equals(model.Id)).SingleOrDefaultAsync().ConfigureAwait(false);

            _logger.LogInformation($"The client table was triggered.");

            return _factory.ToDomain(entity);
        }
        
        public async Task<ClientDomainModel> GetByAttendeeIdAsync(ClientDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetClientByExpression(e => e.AttendeeId.Equals(model.AttendeeId)).SingleOrDefaultAsync().ConfigureAwait(false);

            _logger.LogInformation($"The client table was triggered.");

            return _factory.ToDomain(entity);
        }

        public async Task<ClientDomainModel> UpdateAsync(ClientDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetClientByExpression(e => e.Id.Equals(model.Id)).SingleOrDefaultAsync().ConfigureAwait(false);

            entity.Name = model.Name;
            entity.Surname = model.Surname;
            entity.Age = model.Age;
            entity.ContactNumber = model.ContactNumber;
            entity.Email = model.Email;
            entity.AttendeeId = model.AttendeeId;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation($"The client: {entity} was successfully updated.");

            return _factory.ToDomain(entity);
        }

        private IQueryable<Client> GetAllClients() =>
            _context.Set<Client>();

        private IQueryable<Client> GetClientByExpression(Expression<Func<Client, bool>> expression) =>
            _context.Set<Client>()
                    .Where(expression);
    }
}
