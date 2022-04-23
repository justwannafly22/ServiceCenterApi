using MediatR;
using ProductApi.Boundary.RequestModels;
using System;

namespace ProductApi.Boundary
{
    public class UpdateProductModel : IRequest<ProductResponseModel>
    {
        public UpdateProductModel(Guid id, UpdateProductRequestModel model) 
        {
            Id = id;
            Name = model.Name;
            Price = model.Price;
            Description = model.Description;
        }

        public UpdateProductModel(UpdateProductRequestModel model) 
        {
            Name = model.Name;
            Price = model.Price;
            Description = model.Description;
        }

        public UpdateProductModel() { }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
