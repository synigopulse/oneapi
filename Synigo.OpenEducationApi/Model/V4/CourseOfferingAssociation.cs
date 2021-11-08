using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class CourseOfferingAssociation<TResult> : Association<TResult> where TResult : CourseResult
    {
        [JsonPropertyName("result")]
        public override TResult Result { get; set; }
    }
}
