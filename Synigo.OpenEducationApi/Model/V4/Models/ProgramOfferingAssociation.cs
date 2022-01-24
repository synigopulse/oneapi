using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class ProgramOfferingAssociation<TResult> : Association<TResult> where TResult: ProgramResult
    {
        public static readonly new string ModelType = "https://openonderwijsapi.nl/v4/model#programofferingassociation";

        /// <summary>
        /// Unique id of this association
        /// </summary>
        [Required]
        [JsonPropertyName("associationId")]
        public override Guid AssociationId { get; set; }

        [JsonPropertyName("result")]
        public override TResult Result { get; set; }
    }
}
