using IdentityService.Boundary.Request;
using IdentityService.BusinessLogic;
using IdentityService.Infrastructure.Authorization;
using IdentityService.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationManager _authManager;

        public AuthenticationController(IAuthenticationManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestModel user)
        {
            var result = await _authManager.CreateUser(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.TryAddModelError(error.Code, error.Description);

                return BadRequest(ModelState);
            }

            return Ok(new { Token = await _authManager.CreateToken() });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] AuthUser user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                return Unauthorized();
            }

            return Ok(new { Token = await _authManager.CreateToken() });
        }

        [Authorize(TokenAuthorizationHandler.Policy)]
        [HttpPost("get-permissions")]
        public async Task<IActionResult> Permissions([FromBody] string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return BadRequest("Token is missing!");
            };

            var permissions = await _authManager.GetPermissions(token);

            return Ok(permissions);
        }
    }
}
