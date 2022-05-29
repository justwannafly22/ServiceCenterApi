using MediatR;
using System;

namespace MasterApi.Boundary.Master.RequestModels
{
    public class CreateMasterRequestModel : IRequest<MasterResponseModel>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public Guid AttendeeId { get; set; }
    }
}
