using Newtonsoft.Json;
using Synigo.OneApi.Model.Notifications;

namespace Synigo.OneApi.Clients.Notifications.Models
{
    internal class MessageNotification
    {
        public static readonly string NotificationResource = "ExternalNotifications";

        /// <summary>
        /// Get or set tenant id
        /// </summary>
        [JsonProperty("tenantId")]
        private string TenantId { get; set; }

        /// <summary>
        /// Get or set resource type value
        /// </summary>
        [JsonProperty("resourceType")]
        private string ResourceType { get; set; }

        /// <summary>
        /// Get or set notification content data value
        /// </summary>
        [JsonProperty("data")]
        private NotificationSource Data { get; set; }

        public MessageNotification(string tenantId, PortalNotificationModel notificationModel)
        {
            TenantId = tenantId;
            ResourceType = NotificationResource;
            Data = new NotificationSource(notificationModel);
        }
    }
}
