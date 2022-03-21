using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http;
using System.Threading.Tasks;

namespace Synigo.OneApi.Clients
{
    public class SynigoApiClient
    {
        protected readonly IConfiguration Configuration;
        protected readonly string _clientId;
        protected readonly string _clientSecret;
        protected readonly string _tenantId;
        protected readonly string _synigoApiUrl;
        private static HttpClient _httpClient = new HttpClient();

        public SynigoApiClient(IConfiguration configuration)
        {
            Configuration = configuration;
            _clientId = Configuration.GetSection("AzureAd").GetValue<string>("ClientId");
            _clientSecret = Configuration.GetSection("AzureAd").GetValue<string>("ClientSecret");
            _tenantId = Configuration.GetSection("AzureAd").GetValue<string>("TenantId");
            _synigoApiUrl = Configuration.GetSection("AzureAd").GetValue<string>("SynigoApiUrl");
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            request = await AuthorizeRequest(request);
            return await _httpClient.SendAsync(request);
        }

        private async Task<HttpRequestMessage> AuthorizeRequest(HttpRequestMessage request)
        {
            request.Headers.Add("x-clientid", _clientId);
            request.Headers.Add("x-clientsecret", _clientSecret);
            request.Headers.Add("x-tenantId", _tenantId);
            var token = await AcquireTokenAsync();
            request.Headers.Add("x-token", token);
            return request;
        }

        private async Task<string> AcquireTokenAsync()
        {
            var clientCredential = new ClientCredential(_clientId, _clientSecret);
            var context = new AuthenticationContext($"https://login.microsoftonline.com/{_tenantId}");
            var authenticationResult = await context.AcquireTokenAsync("https://graph.microsoft.com", clientCredential);
            return authenticationResult?.AccessToken;
        }
    }
}
