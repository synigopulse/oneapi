using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class Geolocation
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#geolocation";

        [Required]
        [JsonPropertyName("geoLocationId")]
        public Guid GeoLocationId { get; set; }

        [Required]
        [JsonPropertyName("latitude")]
        public decimal Latitude { get; set; }

        [Required]
        [JsonPropertyName("longitude")]
        public decimal Longitude { get; set; }
    }
}
