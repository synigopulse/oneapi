using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Notifications
{
    public class PushNotificationModel
    {
        /// <summary>
        /// Get or set multi language push notification title
        /// </summary>
        [JsonPropertyName("title")]
        public Dictionary<string, string> Title { get; set; }

        /// <summary>
        /// Get or set multi language push notification message
        /// </summary>
        [JsonPropertyName("message")]
        public Dictionary<string, string> Message { get; set; }

        /// <summary>
        /// Get or set optional url to be opened on notification click
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Get or set list of Microsoft groups ids that will recieve push notification
        /// </summary>
        [JsonPropertyName("groups")]
        public List<string> Groups { get; set; } = new List<string>() { "All" };

        /// <summary>
        /// Get or set a list of individuals that will recieve push notification
        /// </summary>
        [JsonPropertyName("individuals")]
        public List<string> Individuals { get; set; }


    }
}
