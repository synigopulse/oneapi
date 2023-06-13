using System.Collections.Generic;
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
        public string Page { get; set; }

        /// <summary>
        /// Get or set page size
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// Get or set the number of suggested items. The max items shown at your portal is 3
        /// </summary>
        [JsonPropertyName("top")]
        public int? Top { get; set; }

        /// <summary>
        /// Get or set source name
        /// </summary>
        [JsonPropertyName("sourceName")]
        public string SourceName { get; set; }

        [JsonPropertyName("refiners")]
        public List<string> Refiners { get; set; }
    }
}
