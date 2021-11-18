using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Response
{
    public class PageResponse<T>
    {
        /// <summary>
        /// Total number of records
        /// </summary>
        [JsonPropertyName("totalRecords")]
        public int TotalRecords { get; set; }

        /// <summary>
        /// Current page number
        /// </summary>
        [JsonPropertyName("currentIndex")]
        public int CurrentIndex { get; set; }

        /// <summary>
        /// Number of records returned
        /// </summary>
        [JsonPropertyName("currentSize")]
        public int CurrentSize { get; set; }

        /// <summary>
        /// Response
        /// </summary>
        [JsonPropertyName("response")]
        public T Response { get; set; }
    }
}
