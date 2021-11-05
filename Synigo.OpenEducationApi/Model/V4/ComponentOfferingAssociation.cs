using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class ComponentOfferingAssociation : Association
    {
        [JsonPropertyName("Result")]
        public ComponentResult Result { get; set; }
    }
}
