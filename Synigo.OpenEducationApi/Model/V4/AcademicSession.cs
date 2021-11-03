using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// A period in time during which an offering can take place. Academicsessions can be nested.
    /// </summary>
    public class AcademicSession
    {
        /// <summary>
        /// Unique id for this academic session
        /// </summary>
        [JsonPropertyName("academicSessionId")]
        [Required]
        public Guid AcademicSessionId { get; set; }

        /// <summary>
        /// The name of this academic session
        /// </summary>
        /// <example>
        /// Fall semester 2021
        /// </example>
        [MaxLength(256)]
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The day on which this academic session starts, RFC3339 (full-date)
        /// </summary>
        [JsonPropertyName("startDate")]
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The day on which this academic session ends, RFC3339 (full-date)
        /// </summary>
        [JsonPropertyName("endDate")]
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The parent Academicsession of this session (e.g. fall semester 20xx where the current session is a week 40)
        /// </summary>
        [JsonPropertyName("parent")]
        public AcademicSession Parent { get; set; }

        /// <summary>
        /// The top level year of this session (e.g. 20xx where the current session is a week 40 of a semester)
        /// </summary>
        [JsonPropertyName("year")]
        public List<AcademicSession> Year { get; set; }

        /// <summary>
        /// Object for additional non-standard attributes
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; } 

    }
}
