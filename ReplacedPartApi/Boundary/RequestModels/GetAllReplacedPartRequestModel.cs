using MediatR;
using System;
using System.Collections.Generic;

namespace ReplacedPartApi.Boundary.ReplacedParts.RequestModels
{
    public class GetAllReplacedPartRequestModel : IRequest<List<ReplacedPartResponseModel>>
    {
        public GetAllReplacedPartRequestModel(Guid id, RequiredIdType type)
        {
            Id = id;
            RequiredIdType = type;
        }

        public GetAllReplacedPartRequestModel() { }

        public Guid Id { get; set; }
        public RequiredIdType RequiredIdType { get; set; }
    }
}
