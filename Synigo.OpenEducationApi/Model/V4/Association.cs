using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    ///  A relationship between a person object and an offering
    /// </summary>
    public class Association
    {
        /// <summary>
        /// Unique id of this association
        /// </summary>
        [Required]
        [JsonPropertyName("associationId")]
        public Guid AssociationId { get; set; }

        /// <summary>
        /// The type of this association
        /// </summary>
        /// <example>
        /// componentOfferingAssociation
        /// </example>
        [Required]
        [JsonPropertyName("type")]
        public AssociationType Type { get; set; }

        [Required]
        [JsonPropertyName("role")]
        public AssociationRole Role { get; set; }

        [Required]
        [JsonPropertyName("state")]
        public AssociationState State { get; set; }

        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}
