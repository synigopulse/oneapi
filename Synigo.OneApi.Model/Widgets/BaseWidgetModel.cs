using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Widgets
{
    /// <summary>
    /// BaseModel for all widget models
    /// </summary>
    public class BaseWidgetModel
    {
        /// <summary>
        /// Get or set the id of this model
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
