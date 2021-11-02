using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Search
{
    /// <summary>
    /// You'll receive this model when your portal asks for a suggestion
    /// </summary>
    public class SuggestionRequestModel
    {
        /// <summary>
        /// Get or set the query parameters entered by the user
        /// </summary>
        [JsonPropertyName("query")]
        public string Query { get; set; }

        /// <summary>
        /// Get or set the number of suggested items. The max items shown at your portal is 3
        /// </summary>
        [JsonPropertyName("top")]
        public int? Top { get; set; }

    }
}
