using MediatR;
using System;
using System.Collections.Generic;

namespace ProductApi.Boundary.RequestModels
{
    public class GetProductsByClientIdRequestModel : IRequest<List<ProductResponseModel>>
    {
        public Guid ClientId { get; set; }
    }
}
