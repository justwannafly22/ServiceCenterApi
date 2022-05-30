using MediatR;
using System;

namespace ProductApi.Boundary.RequestModels
{
    public class CreateProductRequestModel : IRequest<ProductResponseModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ClientId { get; set; }
    }
}
