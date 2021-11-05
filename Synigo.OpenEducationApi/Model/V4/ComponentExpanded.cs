using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class ComponentExpanded : Component
    {
        /// <summary>
        /// The course of which this component is a part
        /// </summary>
        [JsonPropertyName("course")]
        public Course Course { get; set; }

        /// <summary>
        /// Organization which provides this component
        /// </summary>
        [JsonPropertyName("organization")]
        public Organization Organization { get; set; }
    }
}
