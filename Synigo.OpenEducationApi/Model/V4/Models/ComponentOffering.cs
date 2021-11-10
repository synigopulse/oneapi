using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class ComponentOffering : Offering
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#componentoffering";

        /// <summary>
        /// The moment on which this offering starts, RFC3339 (date-time)
        /// </summary>
        [Required]
        [JsonPropertyName("startDateTime")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// The moment on which this offering ends, RFC3339 (date-time)
        /// </summary>
        [Required]
        [JsonPropertyName("endDateTime")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// The result weight of this offering
        /// </summary>
        [Range(0,100)]
        [JsonPropertyName("resultWeight")]
        public int ResultWeight { get; set; }

        [JsonPropertyName("room")]
        public Room Room { get; set; }

        [JsonPropertyName("component")]
        public Component Component { get; set; }

        [JsonPropertyName("courseOffering")]
        public CourseOffering CourseOffering { get; set; }

        [JsonPropertyName("organization")]
        public Organization Organization { get; set; }
    }
}
