using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class ProgramResult : Result
    {
        /// <summary>
        /// The number of EC's that have been earned to the current moment
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        [JsonPropertyName("ects")]
        public int Ects { get; set; }
    }
}
