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
        /// The keys of the dictionary should be the iso code of the languages.
        /// Currently supported: en-US de-DE, dk-DK, nl-NL, es-ES, it-IT, pl-PL 
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
        public List<string> Groups { get; set; } = new List<string>() { "None" };

        /// <summary>
        /// Get or set a list of individuals that will recieve push notification
        /// </summary>
        [JsonPropertyName("individuals")]
        public List<string> Individuals { get; set; }

        /// <summary>
        /// Get or set if this message is meant for debugging.
        /// If so => You will receive a list UPNS of the recipients in the property DebugRecipients
        /// of the DispatchNotificationResponse.
        /// These UPNS are distincted by language, maximized at 500. The users must have signed in
        /// the application, on their device one time or another..
        /// </summary>
        [JsonPropertyName("debug")]
        public bool Debug { get; set; }

    }
}
