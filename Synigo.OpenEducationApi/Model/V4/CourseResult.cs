using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Synigo.OpenEducationApi.Model.V4;

namespace Synigo.OpenEducationApi.Model.sV4
{
    public class CourseResult : Result
    {
        /// <summary>
        /// The number of EC's that is earned
        /// </summary>
        [Required]
        [JsonPropertyName("ects")]
        public float Ects { get; set; }
    }
}
