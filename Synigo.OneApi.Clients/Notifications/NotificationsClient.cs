using Microsoft.Extensions.Configuration;
using Synigo.OneApi.Clients.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Synigo.OneApi.Clients.Notifications
{
    public class NotificationsClient : INotificationsClient
    {
        private string _synigoUrl = "https://synigo.azure-api.net/test/";
        private readonly IConfiguration Configuration;

        public NotificationsClient(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task SendNotification(NotificationSource notification)
        {
            var clientId = Configuration.GetSection("AzureAd").GetValue<string>("ClientId");
            var clientSecret = Configuration.GetSection("AzureAd").GetValue<string>("ClientSecret");
            var tenantId = Configuration.GetSection("AzureAd").GetValue<string>("TenantId");
            var messageNotification = new MessageNotification(tenantId, notification);
            using(var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{_synigoUrl}/messagenotifications/{tenantId}/messageNotification");
                request.Headers.Add("x-clientid", clientId);
                request.Headers.Add("x-clientSecret", clientSecret);
                request.Headers.Add("x-tenantId", tenantId);
                var token = await GetToken(tenantId, clientId, clientSecret);
                request.Headers.Add("x-token", token);
                request.Content = new StringContent(JsonSerializer.Serialize(messageNotification));
                await client.SendAsync(request);
            }
        }

        public async Task<string> GetToken(string tenantId, string clientId, string clientSecret)
        {
            var clientCredential = new ClientCredential(clientId, clientSecret);
            var context = new AuthenticationContext($"https://login.microsoftonline.com/{tenantId}");
            var authenticationResult = await context.AcquireTokenAsync("https://graph.microsoft.com", clientCredential);
            return authenticationResult?.AccessToken;
        }
    }
}
