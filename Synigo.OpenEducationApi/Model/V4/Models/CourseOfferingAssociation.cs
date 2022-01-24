using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class CourseOfferingAssociation<TResult> : Association<TResult> where TResult : CourseResult
    {
        /// <summary>
        /// Unique id of this association
        /// </summary>
        [Required]
        [JsonPropertyName("associationId")]
        public override Guid AssociationId { get; set; }

        public static readonly new string ModelType = "https://openonderwijsapi.nl/v4/model#courseofferingassociation";
        [JsonPropertyName("result")]
        public override TResult Result { get; set; }
    }
}
