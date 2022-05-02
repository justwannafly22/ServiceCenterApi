using MediatR;
using System;

namespace MasterApi.Boundary.Master.RequestModels
{
    public class DeleteMasterRequestModel : IRequest
    {
        public Guid Id { get; set; }
    }
}
