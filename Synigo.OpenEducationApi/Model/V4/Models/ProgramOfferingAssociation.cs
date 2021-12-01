using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class ProgramOfferingAssociation<TResult> : Association<TResult> where TResult: ProgramResult
    {
        public static readonly new string ModelType = "https://openonderwijsapi.nl/v4/model#programofferingassociation";

        [JsonPropertyName("result")]
        public override TResult Result { get; set; }
    }
}
