using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class CourseOfferingAssociation : Association
    {
        [JsonPropertyName("result")]
        public CourseResult Result { get; set; }
    }
}
