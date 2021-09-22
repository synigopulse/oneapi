using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Search
{
    public class SearchRequestModel
    {
        /// <summary>
        /// Get or set query
        /// </summary>
        [JsonPropertyName("query")]
        public string Query { get; set; }

        /// <summary>
        /// Get or set page
        /// </summary>
        [JsonPropertyName("page")]
        public int Page { get; set; }

        /// <summary>
        /// Get or set page size
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }
    }
}