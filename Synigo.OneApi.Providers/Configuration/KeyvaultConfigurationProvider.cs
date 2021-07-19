using Azure.Core;
using Azure.Security.KeyVault.Secrets;

namespace Synigo.OneApi.Providers.Configuration
{
    public class KeyvaultConfigurationProvider
    {
        private readonly SecretClient _client;
        
        public KeyvaultConfigurationProvider(string vaultUri)
        {
            new UserPasswordCredential();

            _client = new SecretClient(vaultUri);
        }


    }
}
