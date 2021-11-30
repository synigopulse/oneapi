using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class CourseOffering : Offering
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#courseoffering";

        [Required]
        [MaxLength(64)]
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

        /// <summary>
        /// <see cref="Course"/>
        /// </summary>
        [JsonPropertyName("course")]
        public Course Course { get; set; }

        [JsonPropertyName("programOffering")]
        public ProgramOffering ProgramOffering { get; set; }

        /// <summary>
        /// <see cref="Organization"/>
        /// </summary>
        [JsonPropertyName("organization")]
        public Organization Organization { get; set; }
    }
}
