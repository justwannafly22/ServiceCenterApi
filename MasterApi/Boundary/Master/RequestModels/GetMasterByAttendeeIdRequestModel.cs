using MediatR;
using System;

namespace MasterApi.Boundary.Master.RequestModels
{
    public class GetMasterByAttendeeIdRequestModel : IRequest<MasterResponseModel>
    {
        public Guid AttendeeId { get; set; }
    }
}
