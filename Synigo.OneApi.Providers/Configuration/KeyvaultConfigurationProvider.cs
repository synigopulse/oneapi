using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Secrets;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Model.Exceptions;

namespace Synigo.OneApi.Providers.Configuration
{
    public class KeyvaultConfigurationProvider : IConfigurationProvider
    {
        private readonly SecretClient _client;
        private readonly Dictionary<string, string> _configuration;

        public KeyvaultConfigurationProvider(string keyvaultUri, string tenantId, string clientId, string clientSecret)
        {
            if (!Uri.TryCreate(keyvaultUri, UriKind.Absolute, out var vaultUri))
            {
                throw new ConfigurationException($"Could not parse URI to connect to Keyvault:{keyvaultUri}");
            }

            var credential = new Azure.Identity.ClientSecretCredential(tenantId, clientId, clientSecret);
            _client = new SecretClient(vaultUri, credential);
            _configuration = new Dictionary<string, string>();
        }

        public async Task<string> GetAsync(string key)
        {
            if (_configuration.ContainsKey(key))
            {
                return _configuration[key];
            }

            try
            {
                await Load();
            }
            catch (Exception ex)
            {
                throw new ConfigurationException($"Failed to load configuration from: {_client.VaultUri}", ex);
            }

            if (_configuration.ContainsKey(key))
            {
                throw new ConfigurationException($"Configuration key: {key} not found in configuration");
            }

            return key;
        }

        public async Task Load()
        {
            var props = _client.GetPropertiesOfSecretsAsync();
            var secretNames = new List<string>();
            string continuationToken = null;

            await foreach (var page in props.AsPages(continuationToken))
            {
                continuationToken = page.ContinuationToken;
                secretNames.AddRange(page.Values.Select(v => v.Name));
            }

            foreach (var name in secretNames)
            {
                var secret = await _client.GetSecretAsync(name);

                if (secret?.Value?.Value != null)
                {
                    _configuration[name] = secret.Value.Value;
                }
            }
        }

        public void Reset()
        {
            _configuration.Clear();
        }
    }
}
