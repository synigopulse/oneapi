using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Notifications
{
    public class PortalNotificationModel
    {
        /// <summary>
        /// Get or set multilanguage title of the notification
        /// </summary>
        [JsonPropertyName("title")]
        public Dictionary<string, string> Title { get; set; }

        /// <summary>
        /// Get or set multilanguage description of the notification
        /// </summary>
        [JsonPropertyName("description")]
        public Dictionary<string, string> Description { get; set; }

        /// <summary>
        /// Get or set the image of notification
        /// </summary>
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Get or set the url of the notification
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Get or set the type of this source
        /// </summary>
        [JsonPropertyName("notificationTypeIdentifier")]
        public string NotificationTypeIdentifier { get; set; }

        /// <summary>
        /// Get or set the action 
        /// </summary>
        [JsonPropertyName("action")]
        public NotificationActionEnum Action { get; set; }

        /// <summary>
        /// Get or set groups that will receive notifications
        /// </summary>
        [JsonPropertyName("groups")]
        public List<string> Groups { get; set; }

        /// <summary>
        /// Get or set individuals that will receive notification
        /// </summary>
        [JsonPropertyName("individuals")]
        public List<string> Individuals { get; set; }
    }
}
