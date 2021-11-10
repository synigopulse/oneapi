using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class Geolocation
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }
}
