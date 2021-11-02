using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Search
{
    public class SuggestionResponse
    {
        [JsonPropertyName("searchSourceType")]
        public int SearchSourceType { get { return 200; } }

        [JsonPropertyName("searchSourceName")]
        public string SearchSourceName { get; set; }

        [JsonPropertyName("items")]
        public List<SuggestionResponseItem> Items { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }
    }
}
