using Newtonsoft.Json;
using System.Collections.Generic;

namespace Synigo.OneApi.Clients.Notifications.Models
{
    public class MessageNotification
    {
        static readonly string NotificationResource = "ExternalNotifications";

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

        public MessageNotification(string tenantId, NotificationSource notificationSource)
        {
            TenantId = tenantId;
            ResourceType = NotificationResource;
            Data = notificationSource;
            Data.ParentType = NotificationResource;
        }

        public MessageNotification(string tenantId, Dictionary<string, string> multiTitle, Dictionary<string, string> multiDescription, string typeIdentifier, string imageUrl = null, string url = null, NotificationAction action = NotificationAction.Created)
        {
            TenantId = tenantId;
            ResourceType = NotificationResource;
            Data = new NotificationSource(multiTitle, multiDescription, typeIdentifier, imageUrl, url, action);
            Data.ParentType = NotificationResource;
        }

        public MessageNotification(string tenantId,string title, string description, string typeIdentifier, string imageUrl = null, string url = null, NotificationAction action = NotificationAction.Created)
        {
            TenantId = tenantId;
            ResourceType = NotificationResource;
            Data = new NotificationSource(title, description, typeIdentifier, imageUrl, url, action);
            Data.ParentType = NotificationResource;
        }
    }
}
