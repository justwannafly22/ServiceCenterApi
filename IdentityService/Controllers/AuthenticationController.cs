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
    [Route("api/v1/clients")]
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

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestModel userForRegistration)
        {
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.TryAddModelError(error.Code, error.Description);

                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuth)
        {
            if (!await _authManager.ValidateUser(userForAuth))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authenticaton failed. Wrong user name or password.");
                return Unauthorized();
            }

            return Ok(new { Token = await _authManager.CreateToken() });
        }
    }
}
