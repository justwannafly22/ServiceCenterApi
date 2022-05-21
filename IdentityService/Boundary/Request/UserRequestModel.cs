using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityService.Boundary.Request
{
    public class UserRequestModel
    {
        [Required]
        public string EmailOrLogin { get; set; }

        [Required]
        public string Password { get; set; }
        public ICollection<string> Roles { get; set; }
    }

    public class UserAuthRequestModel
    {
        [Required]
        public string EmailOrLogin { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
