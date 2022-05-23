using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MasterApi.Infrastructure.Authorization
{
    public class TokenAuthenticationHandler : AuthenticationHandler<TokenKeyOptions>
    {
        public const string AuthenticationScheme = "Headers";

        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public TokenAuthenticationHandler(IOptionsMonitor<TokenKeyOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            const string invalidToken = "Invalid token.";
            const string missingToken = "Missing token.";

            var token = Context.Request.Headers["Bearer"];
            if (string.IsNullOrWhiteSpace(token)) return AuthenticateResult.Fail(missingToken);

            var key = Environment.GetEnvironmentVariable("SECRET");
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(key)) return AuthenticateResult.Fail(invalidToken);

            var validationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };

            try
            {
                var claimsPrincipal = _jwtSecurityTokenHandler.ValidateToken(token, validationParameters, out _);
                return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, AuthenticationScheme));
            }
            catch (Exception)
            {
                return AuthenticateResult.Fail(invalidToken);
            }
        }
    }
}
