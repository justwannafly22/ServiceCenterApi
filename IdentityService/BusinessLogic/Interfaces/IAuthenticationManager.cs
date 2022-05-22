using IdentityService.Boundary.Request;
using IdentityService.Boundary.Response;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IdentityService.BusinessLogic
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserRequestModel userForAuth);
        Task<string> CreateToken();
        Task<IdentityResult> CreateUser(UserRequestModel request);
        Task<UserResponseModel> GetPermissions(string token);
    }
}
