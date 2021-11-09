using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class CourseOffering : Offering
    {
        [Required]
        [JsonPropertyName("modeOfStudy")]
        public ModeOfStudy ModeOfStudy { get; set; }

        /// <summary>
        /// The moment on which this offering starts, RFC3339 (full-date)
        /// </summary>
        [Required]
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The moment on which this offering ends, RFC3339 (full-date)
        /// </summary>
        [Required]
        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }
    }
}
