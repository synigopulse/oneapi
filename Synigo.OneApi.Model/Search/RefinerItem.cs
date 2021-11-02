using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Search
{
    public class RefinerItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("count")]
        public int? Count { get; set; }
    }
}
