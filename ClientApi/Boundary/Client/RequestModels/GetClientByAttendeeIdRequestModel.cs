using ClientApi.Boundary.Client.ResponseModels;
using MediatR;
using System;

namespace ClientApi.Boundary.Client.RequestModels
{
    public class GetClientByAttendeeIdRequestModel : IRequest<ClientResponseModel>
    {
        public Guid AttendeeId { get; set; }
    }
}