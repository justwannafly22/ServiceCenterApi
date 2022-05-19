using Microsoft.AspNetCore.Identity;

namespace IdentityService.Repository.Entities
{
    public class User : IdentityUser
    {
        public string EmailOrLogin { get; set; }
        public string Password { get; set; }
    }
}
