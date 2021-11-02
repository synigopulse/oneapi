using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Widgets
{
    /// <summary>
    /// The list item model can be used to populate the my list widget.
    /// </summary>
    public class ListItemModel
    {
        public static readonly string SynigoType = "https://synigo.model#mylist";

        /// <summary>
        /// Get or set the title of this listitem
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Get or set the subtitle of this listitem
        /// </summary>
        [JsonPropertyName("subTitle")]
        public string SubTitle { get; set; }

        /// <summary>
        /// Get or set the url of this listitem
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Get or set a link to an optional icon for this listitem
        /// </summary>
        [JsonPropertyName("iconUrl")]
        public string IconUrl { get; set; }

        /// <summary>
        /// Get or set a list of children for this listitem
        /// </summary>
        [JsonPropertyName("children")]
        public List<ListItemModel> Children { get; set; }

        /// <summary>
        /// Get or set an extension object containing additional data for this listitem
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}
