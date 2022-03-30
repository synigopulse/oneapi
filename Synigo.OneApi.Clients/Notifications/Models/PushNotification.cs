using Newtonsoft.Json;
using Synigo.OneApi.Model.Notifications;
using System.Collections.Generic;

namespace Synigo.OneApi.Clients.Notifications.Models
{
    internal class PushNotification
    {
        /// <summary>
        /// Get or set tenant id
        /// </summary>
        [JsonProperty("tenantId")]
        public string TenantId { get; set; }

        /// <summary>
        /// Get or set multi language push notification title
        /// </summary>
        [JsonProperty("title")]
        public Dictionary<string, string> Title { get; set; }

        /// <summary>
        /// Get or set multi language push notification message
        /// </summary>
        [JsonProperty("message")]
        public Dictionary<string, string> Message { get; set; }

        /// <summary>
        /// Get or set additional data that can be interoreted
        /// </summary>
        [JsonProperty("data")]
        private Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Get or set list of Microsoft groups ids that will recieve push notification
        /// </summary>
        [JsonProperty("groups")]
        public List<string> Groups { get; set; } = new List<string>() { "All" };

        /// <summary>
        /// Get or set a list of individuals that will recieve push notification
        /// </summary>
        [JsonProperty("individuals")]
        public List<string> Individuals { get; set; }

        /// <summary>
        /// Get or set message type
        /// </summary>
        [JsonProperty("messageType")]
        private MessageType MessageType { get; set; }

        public PushNotification() {
            MessageType = MessageType.NotificationMessage;
        }

        public PushNotification(string tenantId, PushNotificationModel pushNotificationModel)
        {
            TenantId = tenantId;
            MessageType = MessageType.NotificationMessage;
            Title = pushNotificationModel.Title;
            Message = pushNotificationModel.Message;
            if (!string.IsNullOrEmpty(pushNotificationModel.Url))
            {
                SetDataUrl(pushNotificationModel.Url);
            }
            Groups = pushNotificationModel.Groups;
            Individuals = pushNotificationModel.Individuals;

        }

        /// <summary>
        /// Sets url to be opened when notification is clicked
        /// </summary>
        /// <param name="url">Url</param>
        private void SetDataUrl(string url)
        {
            Data = new Dictionary<string, string>();
            Data.Add("url", $"synigo://web?source={url}");
        }
    }
}
