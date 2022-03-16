using Newtonsoft.Json;
using System.Collections.Generic;

namespace Synigo.OneApi.Clients.Notifications.Models
{
    public class PushNotification
    {
        /// <summary>
        /// Get or set tenant id
        /// </summary>
        [JsonProperty("tenantId")]
        public string TenantId { get; set; }

        /// <summary>
        /// Get or set user id of the person that recieves push notification
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Get or set list of Microsoft groups ids that will recieve push notification
        /// In order to send notification to all users in organization set valkue to "All"
        /// </summary>
        [JsonProperty("groups")]
        public List<string> Groups { get; set; } = new List<string>() { "All" };

        /// <summary>
        /// get or set a list of individuals that will recieve push notification
        /// </summary>
        [JsonProperty("individuals")]
        public List<string> Individuals { get; set; }

        /// <summary>
        /// Get or set multi language push notification message
        /// </summary>
        [JsonProperty("message")]
        public Dictionary<string, string> Message { get; set; }

        /// <summary>
        /// Get or set multi language push notification title
        /// </summary>
        [JsonProperty("title")]
        public Dictionary<string, string> Title { get; set; }

        /// <summary>
        /// Get or set additional data that can be interoreted
        /// </summary>
        [JsonProperty("data")]
        private Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();

        [JsonProperty("messageType")]
        private MessageType MessageType { get; set; }

        public PushNotification() {
            MessageType = MessageType.NotificationMessage;
        }

        public PushNotification(string _tenantId, Dictionary<string, string> title, Dictionary<string, string> message, List<string> groups = null, string userId = null, List<string> individuals = null, string url = null)
        {
            TenantId = _tenantId;
            Title = title;
            Message = message;
            UserId = userId;
            Groups = groups;
            Individuals = individuals;
            if (!string.IsNullOrEmpty(url))
            {
                SetDataUrl(url);
            }
            MessageType = MessageType.NotificationMessage;
        }

        /// <summary>
        /// Make notification available for all users in  organization
        /// </summary>
        public void MakeAvailableForAllUsers()
        {
            Groups = new List<string>() { "All" };
        }

        /// <summary>
        /// Sets url to be opened when notification is clicked
        /// </summary>
        /// <param name="url">Url</param>
        public void SetDataUrl(string url)
        {
            Data = new Dictionary<string, string>();
            Data.Add("url", $"synigo://web?source={url}");
        }
    }
}
