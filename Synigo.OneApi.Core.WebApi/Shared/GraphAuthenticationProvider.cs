using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace Synigo.OneApi.Core.WebApi.Shared
{
    /// <summary>
    /// Implementation to pass asuthentication enrichment of requests
    /// to Graph Client
    /// </summary>
    public class GraphAuthenticationProvider : IAuthenticationProvider
    {
        private readonly IConfidentialClientApplication _app;

        public GraphAuthenticationProvider(IConfidentialClientApplication app)
        {
            _app = app;
        }

        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var scopes = new string[] { "https://graph.microsoft.com/.default" };
            var result = await _app.AcquireTokenForClient(scopes).ExecuteAsync();
            request.Headers.Add("Authorization", "Bearer " + result.AccessToken);
        }
    }
}
