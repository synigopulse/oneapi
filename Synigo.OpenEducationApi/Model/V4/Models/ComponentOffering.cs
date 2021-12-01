using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class ComponentOffering : Offering
    {
        public static readonly new string ModelType = "https://openonderwijsapi.nl/v4/model#componentoffering";

        /// <summary>
        /// The result weight of this offering
        /// </summary>
        [Range(0,100)]
        [JsonPropertyName("resultWeight")]
        public int? ResultWeight { get; set; }

        /// <summary>
        /// <see cref="Room"/>
        /// </summary>
        [JsonPropertyName("room")]
        public Room Room { get; set; }

        /// <summary>
        /// <see cref="Component"/>
        /// </summary>
        [JsonPropertyName("component")]
        public Component Component { get; set; }

        /// <summary>
        /// <see cref="CourseOffering"/>
        /// </summary>
        [JsonPropertyName("courseOffering")]
        public CourseOffering CourseOffering { get; set; }

        /// <summary>
        /// <see cref="Organization"/>
        /// </summary>
        [JsonPropertyName("organization")]
        public Organization Organization { get; set; }
    }
}
