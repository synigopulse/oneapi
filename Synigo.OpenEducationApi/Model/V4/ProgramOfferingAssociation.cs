using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class ProgramOfferingAssociation<TResult> : Association<TResult> where TResult: ProgramResult
    {
        [JsonPropertyName("result")]
        public override TResult Result { get; set; }
    }
}
