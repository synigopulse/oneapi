using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    ///  A placeholder or collection of news items 
    /// </summary>
    public class NewsFeed
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#newsfeed";

        /// <summary>
        /// Unique id for this news feed
        /// </summary>
        [Required]
        [JsonPropertyName("newsFeedId")]
        public Guid NewsFeedId { get; set; }

        /// <summary>
        /// The name for this news feed
        /// </summary>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of this news feed
        /// </summary>
        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The type of the object this news feed relates to
        /// </summary>
        [Required]
        [JsonPropertyName("type")]
        public NewsFeedType Type { get; set; }

        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}
