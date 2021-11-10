using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4.Models
{
    public class ComponentOfferingAssociation<TResult> : Association<TResult> where TResult : ComponentResult
    {
        [JsonPropertyName("result")]
        public override TResult Result { get; set; }
    }
}
