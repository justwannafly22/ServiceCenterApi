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
        private readonly JwtSecurityTokenHandler _jwtHandler;

        private User _user;
        private const string AttendeeId = "AttendeeId";
        private const string Username = "Username";

        public AuthenticationManager(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtHandler = new JwtSecurityTokenHandler();
        }

        public async Task<IdentityResult> CreateUser(UserRequestModel request)
        {
            var user = new User()
            {
                UserName = request.Email,
                Email = request.Email,
                Password = PasswordService.HashPassword(request.Password)
            };

            var result = await _userManager.CreateAsync(user, user.Password);
            await _userManager.AddToRoleAsync(user, request.Role);
            _user = user;

            return result;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSingningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<bool> ValidateUser(AuthUser request)
        {
            _user = await _userManager.FindByEmailAsync(request.Email);

            return PasswordService.DoesPasswordMatch(request.Password, _user.Password);
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
                new Claim(Username, _user.UserName),
                new Claim(AttendeeId, _user.Id.ToString())
            };

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddSeconds(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }

        public async Task<UserResponseModel> GetPermissions(string token)
        {
            var claims = _jwtHandler.ReadJwtToken(token).Claims;
            if (claims is null)
            {
                throw new Exception("Failed to extract claims from token.");
            }

            var emailOrLoginName = GetClaim(claims, Username).ToString();

            var user = await _userManager.FindByNameAsync(emailOrLoginName);
            var roles = await _userManager.GetRolesAsync(user);

            return new UserResponseModel
            {
                AttendeeId = new Guid(user.Id),
                Roles = roles
            };
        }

        private static object GetClaim(IEnumerable<Claim> claims, string claimName)
        {
            return claims.FirstOrDefault(x => x.Type.Equals(claimName)).Value;
        }
    }
}
