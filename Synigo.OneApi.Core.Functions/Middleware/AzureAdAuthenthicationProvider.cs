using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Synigo.OneApi.Core.Functions.Middleware
{
    public class AzureAdAuthenthicationProvider : IAuthenthicationProvider
    {
        private readonly JwtSecurityTokenHandler _tokenValidator;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private ConfigurationManager<OpenIdConnectConfiguration> _configurationManager;
        private readonly IConfiguration _configuration;

        public AzureAdAuthenthicationProvider(
             IConfiguration configuration)
        {
            _tokenValidator = new JwtSecurityTokenHandler();
            _tokenValidationParameters = new TokenValidationParameters();
            _configuration = configuration;
        }

        public async Task<ClaimsPrincipal> AuthenticateAsync(FunctionContext context)
        {
            if (!TryGetTokenFromHeaders(context, out var token))
                throw new SecurityTokenException("Can't read token");

            if (!_tokenValidator.CanReadToken(token))
                throw new SecurityTokenException("Can't read token");
            var clientId = _configuration.GetSection("AzureAd").GetValue<string>("ClientId");
            var tenantId = _configuration.GetSection("AzureAd").GetValue<string>("TenantId");

            return await Validate(clientId, tenantId, token);
        }

        public async Task<ClaimsPrincipal> Validate(string clientId, string aplicationId, string token)
        {
            if (!_tokenValidator.CanReadToken(token))
            {
                throw new SecurityTokenException("Can't read token");
            }

            _configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
              $"https://login.microsoftonline.com/{aplicationId}/.well-known/openid-configuration",
              new OpenIdConnectConfigurationRetriever());

            var openIdConfig = await _configurationManager.GetConfigurationAsync();

            _tokenValidationParameters.ValidAudience = $"{clientId}";
            _tokenValidationParameters.ValidIssuer = openIdConfig.Issuer;
            _tokenValidationParameters.IssuerSigningKeys = openIdConfig.SigningKeys;
            _tokenValidationParameters.ValidateAudience = false;

            return _tokenValidator.ValidateToken(token, _tokenValidationParameters, out _);
        }

        private static bool TryGetTokenFromHeaders(FunctionContext context, out string token)
        {
            token = null;
            // HTTP headers are in the binding context as a JSON object
            // The first checks ensure that we have the JSON string
            if (!context.BindingContext.BindingData.TryGetValue("Headers", out var headersObj))
            {
                return false;
            }

            if (headersObj is not string headersStr)
            {
                return false;
            }

            // Deserialize headers from JSON
            var headers = JsonSerializer.Deserialize<Dictionary<string, string>>(headersStr);
            var normalizedKeyHeaders = headers.ToDictionary(h => h.Key.ToLowerInvariant(), h => h.Value);
            if (!normalizedKeyHeaders.TryGetValue("authorization", out var authHeaderValue))
            {
                // No Authorization header present
                return false;
            }

            if (!authHeaderValue.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                // Scheme is not Bearer
                return false;
            }

            token = authHeaderValue.Substring("Bearer ".Length).Trim();
            return true;
        }
    }
}
