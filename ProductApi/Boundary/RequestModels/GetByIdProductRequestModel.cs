using MediatR;
using System;

namespace ProductApi.Boundary.RequestModels
{
    public class GetByIdProductRequestModel : IRequest<ProductResponseModel>
    {
        public Guid Id { get; set; }
    }
}
