using IdentityService.Boundary.Request;
using IdentityService.BusinessLogic;
using IdentityService.Repository.Entities;
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
        private readonly UserManager<User> _userManager;
        private readonly ILogger _logger;

        public AuthenticationController(IAuthenticationManager authManager, UserManager<User> userManager, ILogger logger)
        {
            _authManager = authManager;
            _userManager = userManager;
            _logger = logger;
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

            _logger.LogInformation("User successfully created.");

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserRequestModel user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarning($"{nameof(Authenticate)}: Authenticaton failed. Wrong user name or password.");
                return Unauthorized();
            }

            return Ok(new { Token = await _authManager.CreateToken() });
        }

        [HttpPost]
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
