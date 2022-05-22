using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityService.Boundary.Request
{
    public class UserRequestModel
    {
        [Required]
        public string EmailOrLogin { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Guid AttendeeId { get; set; }
    }
}
