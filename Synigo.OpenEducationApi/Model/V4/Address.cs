using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The full street address
    /// </summary>
    public class Address
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#address";

        /// <summary>
        /// Get or set the <see cref="PostalType"/> of the address
        /// </summary>
        [Required]
        [JsonPropertyName("type")]
        public PostalType PostalType { get; set; }

        /// <summary>
        /// Get or set the street name
        /// </summary>
        [JsonPropertyName("street")]
        public string Street { get; set; }

        /// <summary>
        /// Get or set the street number
        /// </summary>
        [JsonPropertyName("streetNumber")]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Get or set further details like building name, suite, apartment number, etc.
        /// </summary>
        [JsonPropertyName("additional")]
        public string Additional { get; set; }

        /// <summary>
        /// Get or set postal code
        /// </summary>
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Get or set name of the city / locality
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// Get or set the country code according to [iso-3166-1-alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
        /// </summary>
        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Get or set the geolocation of the entrance of this address (WGS84 coordinate reference system)
        /// </summary>
        [JsonPropertyName("geolocation")]
        public Geolocation Geolocation { get; set; }

        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}

