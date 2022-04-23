using MediatR;

namespace ProductApi.Boundary.RequestModels
{
    public class CreateProductRequestModel : IRequest<ProductResponseModel>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
