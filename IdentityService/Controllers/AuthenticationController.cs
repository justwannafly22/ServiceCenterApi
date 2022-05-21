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
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestModel userForRegistration)
        {
            var result = await _authManager.CreateUser(userForRegistration);

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
        public async Task<IActionResult> Authenticate([FromBody] UserAuthRequestModel userForAuth)
        {
            if (!await _authManager.ValidateUser(userForAuth))
            {
                _logger.LogWarning($"{nameof(Authenticate)}: Authenticaton failed. Wrong user name or password.");
                return Unauthorized();
            }

            return Ok(new { Token = await _authManager.CreateToken() });
        }
    }
}
