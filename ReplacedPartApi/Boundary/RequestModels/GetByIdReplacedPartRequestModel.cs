using MediatR;
using System;

namespace ReplacedPartApi.Boundary.ReplacedParts.RequestModels
{
    public class GetByIdReplacedPartRequestModel : IRequest<ReplacedPartResponseModel>
    {
        public GetByIdReplacedPartRequestModel(Guid id)
        {
            Id = id;
        }

        public GetByIdReplacedPartRequestModel() { }

        public Guid Id { get; set; }
    }
}
