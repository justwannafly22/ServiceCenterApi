using ReplacedPartApi.Domain;
using ReplacedPartApi.Repository.Entities;
using System;

namespace ReplacedPartApi.Infrastructure.Extensions
{
    public static class ReplacedPartFactory
    {
        public static ReplacedPartDomainModel ToDomain(this ReplacedPart model)
        {
            if (model is null)
            {
                throw new ArgumentNullException($"The replaced part was not found.");
            }

            return new ReplacedPartDomainModel
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Count = model.Count,
                AdvancedInfo = model.AdvancedInfo,
                RepairId = model.RepairId,
                ProductId = model.ProductId
            };
        }

        public static ReplacedPart ToEntity(this ReplacedPartDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException($"The replaced part is null.");
            }

            return new ReplacedPart
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Count = model.Count,
                AdvancedInfo = model.AdvancedInfo,
                RepairId = model.RepairId,
                ProductId = model.ProductId
            };
        }
    }
}
