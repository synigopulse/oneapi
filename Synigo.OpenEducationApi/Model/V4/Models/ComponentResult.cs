using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class ComponentResult : Result
    {
        /// <summary>
        /// The weight to 100 as total for this offering in the course
        /// - minimum: 0
        //  - maximum: 100
        /// </summary>
        [Required]
        [Range(0, 100)]
        [JsonPropertyName("range")]
        public Range Weight { get; set; }
    }
}
