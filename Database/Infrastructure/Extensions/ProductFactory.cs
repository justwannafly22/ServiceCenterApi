using Database.Domain;
using System;

namespace Database.Infrastructure
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
                Description = model.Description,
                ClientId = model.ClientId
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
                Description = model.Description,
                ClientId = model.ClientId
            };
        }
    }
}
