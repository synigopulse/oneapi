using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// These properties are only present when explicitly included
    /// </summary>
    public class AssociationExpanded  
    {
        /// <summary>
        /// The person this association is to
        /// </summary>
        [JsonPropertyName("person")]
        public Person Person { get; set; }

        [JsonPropertyName("offering")]
        public Offering Offering { get; set; }
    }
}
