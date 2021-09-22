using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Search
{
    public abstract class BaseSearchResponseModel
    {
        /// <summary>
        /// Get or set the title of this search result
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Get or set the subtitle of this search result
        /// </summary>
        [JsonPropertyName("subTitle")]
        public string SubTitle { get; set; }

        /// <summary>
        /// Get or set the url of this search result
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
