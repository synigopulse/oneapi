using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    ///  A relationship between a person object and an offering
    /// </summary>
    public class Association<TResult>  where TResult : Result
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#association";
        /// <summary>
        /// Unique id of this association
        /// </summary>
        [Required]
        [JsonPropertyName("associationId")]
        public virtual Guid AssociationId { get; set; }

        /// <summary>
        /// The type of this association
        /// </summary>
        /// <example>
        /// componentOfferingAssociation
        /// </example>
        [Required]
        [MaxLength(64)]
        [JsonPropertyName("type")]
        public AssociationType Type { get; set; }

        /// <summary>
        /// The <see cref="AssociationRole"/> of this Association
        /// </summary>
        [Required]
        [MaxLength(64)]
        [JsonPropertyName("role")]
        public AssociationRole Role { get; set; }

        /// <summary>
        /// <see cref="AssociationState"/>
        /// </summary>
        [Required]
        [MaxLength(64)]
        [JsonPropertyName("state")]
        public AssociationState State { get; set; }

        /// <summary>
        /// The <see cref="Result"/> in this Association
        /// </summary>
        [JsonPropertyName("result")]
        public virtual TResult Result { get; set; }

        /// <summary>
        /// The <see cref="Person"/> in this Association
        /// </summary>
        [JsonPropertyName("person")]
        public virtual Person Person { get; set; }

        /// <summary>
        /// The <see cref="Offering"/> in this Association
        /// </summary>
        [JsonPropertyName("offering")]
        public virtual Offering Offering { get; set; }

        /// <summary>
        /// Object for additional non-standard attributes
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}
