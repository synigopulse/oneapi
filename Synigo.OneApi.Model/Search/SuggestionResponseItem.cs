using System;
using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Search
{
    public class SuggestionResponseItem
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("subTitle")]
        public string SubTitle { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }
    }
}
