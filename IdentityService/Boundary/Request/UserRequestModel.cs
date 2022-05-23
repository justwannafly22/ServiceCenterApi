using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityService.Boundary.Request
{
    public class UserRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Guid AttendeeId { get; set; }

        [Required]
        public string Role { get; set; }
    }

    public class AuthUser
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
