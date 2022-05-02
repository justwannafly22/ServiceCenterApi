using MediatR;
using System;

namespace MasterApi.Boundary.Master.RequestModels
{
    public class GetMasterByIdRequestModel : IRequest<MasterResponseModel>
    {
        public Guid Id { get; set; }
    }
}
