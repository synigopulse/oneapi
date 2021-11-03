using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// A result as part of an association 
    /// </summary>
    public class Result
    {
        /// <summary>
        /// The state of this result
        /// </summary>
        [JsonPropertyName("state")]
        [Required]
        public ResultState State { get; set; }

        /// <summary>
        /// The comment on this result
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// The score of this program/course/component association (based on resultValueType in offering)
        /// </summary>
        [JsonPropertyName("score")]
        public string Score { get; set; }

        /// <summary>
        /// The date this result has been published, RFC3339 (full-date)
        /// </summary>
        [JsonPropertyName("resultDate")]
        [Required]
        public DateTime ResultDate { get; set; }

        /// <summary>
        /// Object for additional non-standard attributes
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}
