using MediatR;
using System;

namespace ProductApi.Boundary.RequestModels
{
    public class DeleteProductRequestModel : IRequest
    {
        public Guid Id { get; set; }
    }
}
