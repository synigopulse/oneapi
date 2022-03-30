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
