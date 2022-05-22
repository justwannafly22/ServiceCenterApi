using IdentityService.Boundary.Request;
using IdentityService.Boundary.Response;
using IdentityService.Repository.Entities;
using JWT.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.BusinessLogic
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtBuilder _jwtBuilder;

        private User _user;
        private const string AttendeeId = "AttendeeId";

        public AuthenticationManager(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtBuilder = JwtBuilder.Create();
        }

        public async Task<IdentityResult> CreateUser(UserRequestModel request)
        {
            var user = new User()
            {
                EmailOrLogin = request.EmailOrLogin,
                Password = PasswordService.HashPassword(request.Password),
                AttendeeId = request.AttendeeId
            };

            var result = await _userManager.CreateAsync(user, user.Password);

            return result;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSingningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<bool> ValidateUser(UserRequestModel request)
        {
            _user = await _userManager.FindByNameAsync(request.EmailOrLogin);

            var hashedPassword = PasswordService.HashPassword(request.Password);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, hashedPassword));
        }

        private SigningCredentials GetSingningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(AttendeeId, _user.AttendeeId.ToString())
            };

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("validIssuer").Value,
                audience: jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddSeconds(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }

        public async Task<UserResponseModel> GetPermissions(string token)
        {
            var claims = _jwtBuilder.Decode<IDictionary<string, object>>(token);
            if (claims is null)
            {
                throw new Exception("Failed to extract claims from token.");
            }

            var attendeeClaim = GetClaim(claims, AttendeeId);
            var attendeeId = ParseIntoGuid(attendeeClaim.ToString());
            var emailOrLoginName = GetClaim(claims, ClaimTypes.Name).ToString();

            var user = await _userManager.FindByNameAsync(emailOrLoginName);
            var roles = await _userManager.GetRolesAsync(user);

            return new UserResponseModel
            {
                AttendeeId = attendeeId,
                Roles = roles
            };
        }

        private static object GetClaim(IDictionary<string, object> claims, string claimName)
        {
            return claims.FirstOrDefault(x => x.Key.Equals(claimName)).Value;
        }

        private static Guid ParseIntoGuid(string claimValue)
        {
            return string.IsNullOrWhiteSpace(claimValue)
                ? Guid.Empty
                : Guid.TryParse(claimValue, out var guid) ? guid : Guid.Empty;
        }
    }
}
