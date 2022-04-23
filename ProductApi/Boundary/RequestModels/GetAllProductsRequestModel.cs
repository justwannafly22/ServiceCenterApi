using MediatR;
using System.Collections.Generic;

namespace ProductApi.Boundary.RequestModels
{
    public class GetAllProductsRequestModel : IRequest<List<ProductResponseModel>>
    {
    }
}
