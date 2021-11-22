using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// A metadataset providing details on the provider of this OOAPI implementation 
    /// </summary>
    public class Service
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#service";

        [Required]
        [JsonPropertyName("serviceId")]
        public Guid ServiceId { get; set; }
        /// <summary>
        /// Contact e-mail address of the service owner
        /// </summary>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("contactEmail")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// URL of the API specification (YAML or JSON, compliant with [Open API Specification v3](https://github.com/OAI/OpenAPI-Specification/))
        /// </summary>
        [Required]
        [MaxLength(2048)]
        [JsonPropertyName("specification")]
        public string Specification { get; set; }

        /// <summary>
        /// URL of the API documentation, including general terms and privacy statement
        /// </summary>
        [Required]
        [MaxLength(2048)]
        [JsonPropertyName("documentation")]
        public string Documentation { get; set; }

        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}
