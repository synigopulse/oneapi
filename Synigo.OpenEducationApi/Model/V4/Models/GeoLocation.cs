using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class Geolocation
    {
        [Required]
        [JsonPropertyName("geoLocationId")]
        public Guid GeoLocationId { get; set; }

        [Required]
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [Required]
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }
}
