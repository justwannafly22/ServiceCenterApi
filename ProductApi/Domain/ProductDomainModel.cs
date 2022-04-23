using System;

namespace ProductApi.Domain
{
    public class ProductDomainModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
