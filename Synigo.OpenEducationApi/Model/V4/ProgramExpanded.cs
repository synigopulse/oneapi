using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class ProgramExpanded : Program
    {
        /// <summary>
        /// Parent program of which the current program is a child.  
        /// </summary>
        [JsonPropertyName("parent")]
        public Program Parent { get; set; }

        /// <summary>
        /// Programs which are a part of this program (e.g specializations)
        /// </summary>
        [JsonPropertyName("children")]
        public List<Program> Chidren { get; set; }

        /// <summary>
        /// The organization providing the current course
        /// </summary>
        [JsonPropertyName("organization")]
        public Organization Organization { get; set; }
    }
}
