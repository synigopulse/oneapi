using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Synigo.OneApi.Clients.Notifications.Models;
using Synigo.OneApi.Model.Notifications;
using System.Net.Http;
using System.Threading.Tasks;

namespace Synigo.OneApi.Clients.Notifications
{
    public class NotificationsClient : INotificationsClient
    {
        private readonly string _tenantId;
        private readonly string _synigoApiUrl;
        private readonly SynigoApiClient _synigoApiClient;

        public NotificationsClient(IConfiguration configuration)
        {
            _tenantId = configuration.GetSection("AzureAd").GetValue<string>("TenantId");
            _synigoApiUrl = configuration.GetSection("AzureAd").GetValue<string>("SynigoApiUrl");
            _synigoApiClient = new SynigoApiClient(configuration);
        }

        public NotificationsClient(string clientId, string clientSecret, string tenantId, string synigoApiUrl)
        {
            _tenantId = tenantId;
            _synigoApiUrl = synigoApiUrl;
            _synigoApiClient = new SynigoApiClient(clientId, clientSecret, tenantId, synigoApiUrl);
        }

        /// <summary>
        /// Sends portal notification to all users in organization
        /// </summary>
        /// <param name="notification" cref="NotificationSource">received NotificationSource model</param>
        /// <returns cref="HttpResponseMessage">Returns HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> SendNotification(PortalNotificationModel notification, string token)
        {
            var messageNotification = new MessageNotification(_tenantId, notification);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{_synigoApiUrl}/messagenotifications/{_tenantId}/messageNotification");
            request.Content = new StringContent(JsonConvert.SerializeObject(messageNotification));
            return await _synigoApiClient.SendAsync(request, token);
        }

        /// <summary>
        /// Sends push notification to mobile application
        /// </summary>
        /// <param name="pushNotification" cref="PushNotification">Push notification model</param>
        /// <returns cref="HttpResponseMessage">Returns HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> SendPushNotification(PushNotificationModel pushNotificationModel, string token)
        {
            var pushNotification = new PushNotification(_tenantId, pushNotificationModel);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{_synigoApiUrl}/pushnotifications/{_tenantId}/message");
            request.Content = new StringContent(JsonConvert.SerializeObject(pushNotification));
            return await _synigoApiClient.SendAsync(request, token);
        }
    }
}
