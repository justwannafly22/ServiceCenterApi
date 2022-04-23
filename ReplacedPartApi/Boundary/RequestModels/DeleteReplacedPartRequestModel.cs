using MediatR;
using System;

namespace ReplacedPartApi.Boundary.ReplacedParts.RequestModels
{
    public class DeleteReplacedPartRequestModel : IRequest
    {
        public Guid Id { get; set; }
    }
}
