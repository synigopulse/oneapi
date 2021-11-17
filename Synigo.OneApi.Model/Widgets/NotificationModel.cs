using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Widgets
{
    /// <summary>
    /// Class represents a notification which is shown in the portal.
    /// e.g. You have 3 new messages or it's time to enter your expense report.
    /// The formatting of the messages can be done in your CMS.
    /// </summary>
    public class NotificationModel
    {
        public static readonly string Type = "https://synigopulse.com/v1/model#notification";
        /// <summary>
        /// Get or set the url, to navigate to, when a user clicks this notication
        /// (optional)
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Get or set the count of this notification. If you use 0 and you choose the "Hide when empty flag"
        /// the notification will not be shown
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }

        /// <summary>
        /// Get or set an extension object containing additional data for this listitem
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}
