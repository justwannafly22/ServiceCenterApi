using IdentityService.Boundary.Request;
using IdentityService.Repository.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.BusinessLogic
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        private User _user;

        public AuthenticationManager(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> CreateUser(UserRequestModel request)
        {
            var user = new User()
            {
                EmailOrLogin = request.EmailOrLogin,
                Password = PasswordService.HashPassword(request.Password)
            };

            var result = await _userManager.CreateAsync(user, user.Password);
            await _userManager.AddToRolesAsync(user, request.Roles);

            return result;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSingningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<bool> ValidateUser(UserAuthRequestModel userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.EmailOrLogin);

            var hashedPassword = PasswordService.HashPassword(userForAuth.Password);
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
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

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
    }
}
