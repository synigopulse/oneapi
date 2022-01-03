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
        public static readonly string Type = "https://openonderwijsapi.nl/v4/model#academicsession";

        /// <summary>
        /// Unique id for this academic session
        /// </summary>
        [Required]
        [JsonPropertyName("academicSessionId")]
        public Guid AcademicSessionId { get; set; }

        /// <summary>
        /// The name of this academic session
        /// </summary>
        /// <example>
        /// Fall semester 2021
        /// </example>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The day on which this academic session starts, RFC3339 (full-date)
        /// </summary>
        [Required]
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The day on which this academic session ends, RFC3339 (full-date)
        /// </summary>
        [Required]
        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The parent Academicsession of this session (e.g. fall semester 20xx where the current session is a week 40)
        /// <see cref="AcademicSession"/>
        /// </summary>
        [JsonPropertyName("parent")]
        public virtual AcademicSession Parent { get; set; }

        /// <summary>
        /// The top level year of this session (e.g. 20xx where the current session is a week 40 of a semester)
        /// <see cref="AcademicSession"/>
        /// </summary>
        [JsonPropertyName("year")]
        public virtual List<AcademicSession> Year { get; set; }

        /// <summary>
        /// Object for additional non-standard attributes
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}
