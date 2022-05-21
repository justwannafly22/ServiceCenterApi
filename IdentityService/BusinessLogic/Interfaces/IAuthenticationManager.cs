using IdentityService.Boundary.Request;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IdentityService.BusinessLogic
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserAuthRequestModel userForAuth);
        Task<string> CreateToken();
        Task<IdentityResult> CreateUser(UserRequestModel request);
    }
}
