using Microsoft.AspNetCore.Identity;
using System;

namespace IdentityService.Repository.Entities
{
    public class User : IdentityUser
    {
        public Guid AttendeeId { get; set; }
        public string EmailOrLogin { get; set; }
        public string Password { get; set; }
    }
}
