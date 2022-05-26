using System;

namespace ProductApi.Boundary
{
    public class ProductResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
