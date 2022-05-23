using System;
using System.Collections.Generic;

namespace IdentityService.Boundary.Response
{
    public class UserResponseModel
    {
        public Guid AttendeeId { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
