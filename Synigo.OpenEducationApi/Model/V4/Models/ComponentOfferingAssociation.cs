using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4.Models
{
    public class ComponentOfferingAssociation<TResult> : Association<TResult> where TResult : ComponentResult
    {
        public static readonly new string ModelType = "https://openonderwijsapi.nl/v4/model#componentofferingassociation";

        [JsonPropertyName("result")]
        public override TResult Result { get; set; }
    }
}
