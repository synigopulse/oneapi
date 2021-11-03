using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Common
{
    public class BreadCrumbItem
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
