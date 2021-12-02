using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The offering of a program
    /// </summary>
    public class ProgramOffering : Offering
    {
        public static readonly new string ModelType = "https://openonderwijsapi.nl/v4/model#programoffering";
        /// <summary>
        /// The <see cref="ModeOfStudy"/> of this ProgramOffering
        /// </summary>
        [Required]
        [MaxLength(64)]
        [JsonPropertyName("modeOffStudy")]
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
        /// The <see cref="Program"/> for this offering
        /// </summary>
        [JsonPropertyName("program")]
        public Program Program { get; set; }
    }
}
