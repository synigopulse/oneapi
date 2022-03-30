using Newtonsoft.Json;
using Synigo.OneApi.Model.Notifications;
using System.Collections.Generic;

namespace Synigo.OneApi.Clients.Notifications.Models
{
    internal class NotificationSource
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
        public string Type { get; set; }

        /// <summary>
        /// Get or set the type of this source
        /// </summary>
        [JsonProperty("parentType")]
        public string ParentType { get; set; }

        /// <summary>
        /// Get or set the action
        /// </summary>
        [JsonProperty("action")]
        public NotificationAction Action { get; set; }

        /// <summary>
        /// Get or set groups that will receive notifications
        /// </summary>
        [JsonProperty("groups")]
        public List<string> Groups { get; set; }

        /// <summary>
        /// Get or set individuals that will receive notification
        /// </summary>
        [JsonProperty("individuals")]
        public List<string> Individuals { get; set; }

        public NotificationSource(PortalNotificationModel portalNotificationModel)
        {
            MultiTitle = portalNotificationModel.Title;
            MultiDescription = portalNotificationModel.Description;
            ImageUrl = portalNotificationModel.ImageUrl;
            Url = portalNotificationModel.Url;
            Type = portalNotificationModel.NotificationTypeIdentifier;
            ParentType = MessageNotification.NotificationResource;
            Action = (NotificationAction)(int)portalNotificationModel.Action;
            Groups = portalNotificationModel.Groups;
            Individuals = portalNotificationModel.Individuals;
        }
    }
}
