using Synigo.OneApi.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Synigo.OneApi.Model.Notifications
{
    public class NotificationSettingModel
    {
        public static readonly string SynigoType = "https://synigo.model#notificationSettings";

        /// <summary>
        /// Get or set multilanguage title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Get or set notification type
        /// </summary>
        [JsonPropertyName("notificationType")]
        public string NotificationType { get; set; }

        /// <summary>
        /// Get or set notification active status
        /// </summary>
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }
}
