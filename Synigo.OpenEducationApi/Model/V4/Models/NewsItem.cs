using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// A newsitem contains the message and metadata of that message 
    /// </summary>
    public class NewsItem
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#newsitem";
        /// <summary>
        ///  Unique id for this news item
        /// </summary>
        [Required]
        [JsonPropertyName("newsItemId")]
        public Guid NewsItemId { get; set; }

        /// <summary>
        /// The name for this news item
        /// </summary>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("newsItemType")]
        public NewsItemType Type { get; set; }

        /// <summary>
        /// The authors of the article with this news item
        /// </summary>
        /// <example>['admin@universiteitvanharderwijk.nl']</example>
        [JsonPropertyName("authors")]
        List<string> Authors { get; set; }

        /// <summary>
        /// The url containing the address of the image belonging to this news item
        /// </summary>
        /// <example>https://upload.wikimedia.org/wikipedia/commons/4/44/Antu_emblem-unavailable.svg</example>
        [MaxLength(2048)]
        [JsonPropertyName("image")]
        public string Image { get; set; }

        /// <summary>
        /// The url containing the address of the article belonging to this news item
        /// </summary>
        /// <example> https://www.universiteitvanharderwijk.nl/cms/ruimtegebrek </example>
        [MaxLength(2048)]
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The content of this news item
        /// </summary>
        /// <example> The room Bb 4.35 will be under maintenance </example>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// The moment from which this news item is valid, RFC3339 (date-time)
        /// </summary>
        /// <example>2020-09-28T08:30:00.000Z</example>
        [JsonPropertyName("validFrom")]
        public DateTime? ValidFrom { get; set; }

        /// <summary>
        /// The moment until which this news item is valid, RFC3339 (date-time)
        /// </summary>
        /// <example>2020-09-30T20:00:00.000Z</example>
        [JsonPropertyName("validUntil")]
        public DateTime? ValidUntil { get; set; }

        /// <summary>
        /// The moment on which this news item was updated, RFC3339 (date-time)
        /// </summary>
        /// <example>2020-09-28T00:00:00.000Z</example>
        [JsonPropertyName("lastModified")]
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// The newsFeeds where this item can be found
        /// </summary>
        [JsonPropertyName("newsFeeds")]
        public List<NewsFeed> NewsFeeds { get; set; }

        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}
