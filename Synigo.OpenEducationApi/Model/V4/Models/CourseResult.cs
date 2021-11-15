using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class CourseResult : Result
    {
        /// <summary>
        /// The number of EC's that is earned
        /// </summary>
        [Required]
        [JsonPropertyName("ects")]
        public decimal Ects { get; set; }
    }
}
