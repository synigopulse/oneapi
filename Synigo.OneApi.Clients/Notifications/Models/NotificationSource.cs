using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Synigo.OneApi.Clients.Notifications.Models
{
    public class NotificationSource
    {
        /// <summary>
        /// Get or set multilanguage title of the notification
        /// </summary>
        [JsonProperty("multiTitle")]
        public Dictionary<string,string> MultiTitle { get; set; }


        /// <summary>
        /// Get or set multilanguage description of the notification
        /// </summary>
        [JsonProperty("multiDescription")]
        public Dictionary<string, string> MultiDescription { get; set; }

        /// <summary>
        /// Get or set the image of notification
        /// </summary>
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Get or set the url of the notification
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Get or set the type of this source
        /// </summary>
        [JsonProperty("type")]
        public string NotificationTypeIdentifier { get; set; }

        /// <summary>
        /// Get or set the action 
        /// Modified or Created
        /// </summary>
        [JsonProperty("action")]
        public NotificationAction Action { get; set; }

        public NotificationSource()
        {

        }

        public NotificationSource(Dictionary<string, string> multiTitle, Dictionary<string, string> multiDescription, string typeIdentifier, string imageUrl = null, string url = null,  NotificationAction action = NotificationAction.Created)
        {
            MultiTitle = multiTitle;
            MultiDescription = multiDescription;
            ImageUrl = imageUrl;
            Url = url;
            Action = action;
            NotificationTypeIdentifier = typeIdentifier;
        }

        public NotificationSource(string title, string description, string typeIdentifier, string imageUrl = null, string url = null, NotificationAction action = NotificationAction.Created)
        {
            MultiTitle = new Dictionary<string, string>();
            MultiDescription = new Dictionary<string, string>();
            MultiTitle.Add("global", title);
            MultiDescription.Add("global", description);
            ImageUrl = imageUrl;
            Url = url;
            Action = action;
            NotificationTypeIdentifier = typeIdentifier;
        }
    }
}
