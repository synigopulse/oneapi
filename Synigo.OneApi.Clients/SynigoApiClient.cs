using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http;
using System.Threading.Tasks;

namespace Synigo.OneApi.Clients
{
    public class SynigoApiClient
    {
        protected readonly string _clientId;
        protected readonly string _clientSecret;
        protected readonly string _tenantId;
        protected readonly string _synigoApiUrl;
        private static HttpClient _httpClient = new HttpClient();

        public SynigoApiClient(IConfiguration configuration)
        {
            _clientId = configuration.GetSection("AzureAd").GetValue<string>("ClientId");
            _clientSecret = configuration.GetSection("AzureAd").GetValue<string>("ClientSecret");
            _tenantId = configuration.GetSection("AzureAd").GetValue<string>("TenantId");
            _synigoApiUrl = configuration.GetSection("AzureAd").GetValue<string>("SynigoApiUrl");
        }

        public SynigoApiClient(string clientId, string clientSecret, string tenantId, string synigoApiUrl)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _tenantId = tenantId;
            _synigoApiUrl = synigoApiUrl;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, string token)
        {
            request = AuthorizeRequest(request, token);
            return await _httpClient.SendAsync(request);
        }

        private HttpRequestMessage AuthorizeRequest(HttpRequestMessage request, string token)
        {
            request.Headers.Add("Authorization", $"Bearer {token}");
            return request;
        }

    }
}
