using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Requests
{
    public class PageRequest<T> : IPageRequest
    {
        /// <summary>
        /// Page number
        /// </summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }
 
        /// <summary>
        /// Number of records per page
        /// </summary>
        [JsonPropertyName("size")]
        public int Size { get; set; }

        /// <summary>
        /// Order params
        /// </summary>
        [JsonPropertyName("orderBy")]
        public List<string> OrderBy { get; set; }

        [JsonPropertyName("request")]
        public T Request { get; set; }
    }
}
