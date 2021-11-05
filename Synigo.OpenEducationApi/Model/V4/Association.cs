using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// A relationship between a person object and an offering
    /// </summary>
    public class Association
    {
        /// <summary>
        /// Unique id of this Association
        /// </summary>
        [Required]
        [JsonPropertyName("associationId")]
        public Guid AssociationId { get; set; }

        /// <summary>
        /// The <see cref="AssociationType"/> of this Association
        /// </summary>
        [Required]
        [JsonPropertyName("type")]
        public AssociationType Type { get; set; }

        /// <summary>
        /// The <see cref="AssociationRole"/> of this Association
        /// </summary>
        [JsonPropertyName("role")]
        [Required]
        public AssociationRole Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("state")]
        [Required]
        public AssociationState State { get; set; }

        /// <summary>
        /// The <see cref="Result"/> in this Association
        /// </summary>
        [JsonPropertyName("result")]
        public Result Result { get; set; }

        /// <summary>
        /// The <see cref="Person"/> in this Association
        /// </summary>
        [JsonPropertyName("person")]
        public Person Person { get; set; }

        /// <summary>
        /// The <see cref="Offering"/> in this Association
        /// </summary>
        [JsonPropertyName("offering")]
        public Offering Offering { get; set; }

        /// <summary>
        /// Object for additional non-standard attributes
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }


}
