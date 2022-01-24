using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class CourseOfferingAssociation<TResult> : Association<TResult> where TResult : CourseResult
    {

        public static readonly new string ModelType = "https://openonderwijsapi.nl/v4/model#courseofferingassociation";
        [JsonPropertyName("result")]
        public override TResult Result { get; set; }
    }
}
