using System;
using Azure.Security.KeyVault.Secrets;
using Synigo.OneApi.Model.Exceptions;

namespace Synigo.OneApi.Providers.Configuration
{
    public class KeyvaultConfigurationProvider
    {
        private readonly SecretClient _client;
        
        public KeyvaultConfigurationProvider(string keyvaultUri)
        {
            if (!Uri.TryCreate(keyvaultUri, UriKind.Absolute, out var vaultUri))
            {
                throw new ConfigurationException($"Could not parse URI to connect to Keyvault:{keyvaultUri}");
            }

            var credential = new Azure.Identity.ClientSecretCredential("", "", "");
            _client = new SecretClient(vaultUri, credential);
        }
    }
}
