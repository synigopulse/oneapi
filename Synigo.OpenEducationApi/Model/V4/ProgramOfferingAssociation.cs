using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class ProgramOfferingAssociation : Association
    {
        [JsonPropertyName("result")]
        public ProgramResult Result { get; set; }
    }
}
