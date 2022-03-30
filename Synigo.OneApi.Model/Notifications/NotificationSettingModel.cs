using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Notifications
{
    public class NotificationSettingModel
    {
        public static readonly string SynigoType = "https://synigo.model#notificationSettings";

        /// <summary>
        /// Get or set notification type
        /// </summary>
        [JsonPropertyName("notificationTypeId")]
        public string NotificationTypeId { get; set; }

        /// <summary>
        /// Get or set title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Get or set notification active status
        /// </summary>
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }
}
