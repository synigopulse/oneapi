using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Synigo.DemoApi.Model;

namespace Synigo.DemoApi
{
	public class TokenProvider
	{
        private readonly AzureAdSettings _azureAdSettings;
        private readonly SynigoSettings _synigoSettings;

        public TokenProvider(AzureAdSettings azureSettings, SynigoSettings synigoSettings)
        {
            _azureAdSettings = azureSettings;
            _synigoSettings = synigoSettings;
        }

        public async Task<string> GetGraphApplicationTokenAsync()
        {
            return await GetApplicationToken($"https://graph.microsoft.com/.default");
        }

        private async Task<string> GetApplicationToken(string scope)
        {
            var cca = ConfidentialClientApplicationBuilder
               .Create(_azureAdSettings.ClientId)
               .WithClientId(_azureAdSettings.ClientId)
               .WithClientSecret(_azureAdSettings.ClientSecret)
               .WithTenantId(_azureAdSettings.TenantId)
               .WithAuthority(new Uri($"{_azureAdSettings.Instance}/{_azureAdSettings.TenantId}"))
               .Build();

            var scopes = new string[] { scope };
            var authResult = await cca.AcquireTokenForClient(scopes)
                                      .ExecuteAsync();
            return authResult.AccessToken;
        }

        public async Task<string> GetSynigoApplicationTokenAsync()
        {
            return await GetApplicationToken($"{_synigoSettings.SynigoResourceId}/.default");
        }
    }
}