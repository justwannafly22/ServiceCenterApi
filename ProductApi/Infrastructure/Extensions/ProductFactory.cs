using ProductApi.Domain;
using ProductApi.Repository.Entities;
using System;

namespace ProductApi.Infrastructure.Extensions
{
    public static class ProductFactory
    {
        public static Product ToEntity(this ProductDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new Product()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description
            };
        }

        public static ProductDomainModel ToDomain(this Product model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ProductDomainModel()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description
            };
        }
    }
}
