using IdentityService.Boundary.Request;
using System.Threading.Tasks;

namespace IdentityService.BusinessLogic
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserRequestModel userForAuth);
        Task<string> CreateToken();
    }
}
