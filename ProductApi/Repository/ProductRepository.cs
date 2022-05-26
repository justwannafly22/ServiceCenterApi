using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductApi.Domain;
using ProductApi.Infrastructure.Extensions;
using ProductApi.Repository.Entities;
using ProductApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly RepositoryDbContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(RepositoryDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ProductDomainModel> CreateAsync(ProductDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = model.ToEntity();
            await _context.Set<Product>().AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation($"The product was successfully created.");

            return entity.ToDomain();
        }

        public async Task DeleteAsync(ProductDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetByExpression(p => p.Id.Equals(model.Id))
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            _context.Remove(entity);

            await _context.SaveChangesAsync(false);

            _logger.LogInformation($"The product with id: {model.Id} was successfully deleted.");
        }

        public async Task<List<ProductDomainModel>> GetAllAsync()
        {
            var entities = await GetAll()
                                .Select(e => e.ToDomain())
                                .ToListAsync()
                                .ConfigureAwait(false);

            _logger.LogInformation($"The Product table was triggered");

            return entities;
        }

        public async Task<ProductDomainModel> GetByIdAsync(ProductDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetByExpression(p => p.Id.Equals(model.Id))
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            _logger.LogInformation($"The Product table was triggered");

            return entity?.ToDomain();
        }

        public async Task<ProductDomainModel> UpdateAsync(ProductDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = await GetByExpression(p => p.Id.Equals(model.Id))
                              .SingleOrDefaultAsync()
                              .ConfigureAwait(false);

            entity.Name = model.Name;
            entity.Description = model.Description;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation($"The product with id: {model.Id} was successfully updated.");

            return entity.ToDomain();
        }

        private IQueryable<Product> GetAll() =>
            _context.Set<Product>();

        private IQueryable<Product> GetByExpression(Expression<Func<Product, bool>> expression) =>
            _context.Set<Product>()
                    .Where(expression);
    }
}
