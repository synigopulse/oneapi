using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class CourseOffering : Offering
    {
        public static readonly new string ModelType = "https://openonderwijsapi.nl/v4/model#courseoffering";

        [Required]
        [MaxLength(64)]
        [JsonPropertyName("modeOfStudy")]
        public ModeOfStudy ModeOfStudy { get; set; }

        /// <summary>
        /// <see cref="Course"/>
        /// </summary>
        [JsonPropertyName("course")]
        public virtual Course Course { get; set; }

        [JsonPropertyName("programOffering")]
        public virtual ProgramOffering ProgramOffering { get; set; }

        public virtual List<ComponentOffering> ComponentOfferings { get; set; }
    }
}
