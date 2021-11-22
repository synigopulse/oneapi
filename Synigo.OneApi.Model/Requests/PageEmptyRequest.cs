using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Requests
{
    public class PageEmptyRequest : IPageRequest
    {
        /// <summary>
        /// Page number
        /// </summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }
       
        /// <summary>
        /// Page size
        /// </summary>
        [JsonPropertyName("size")]
        public int Size { get; set; }
        
        /// <summary>
        /// Order parameters
        /// </summary>
        [JsonPropertyName("orderBy")]
        public List<string> OrderBy { get; set; }
    }
}
