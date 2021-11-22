using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Requests
{
    public class PageEmptyRequest : IPageRequest
    {
        /// <summary>
        /// Page number
        /// </summary>
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }
       
        /// <summary>
        /// Page size
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }
        
        /// <summary>
        /// Order parameters
        /// </summary>
        [JsonPropertyName("sort")]
        public List<string> Sort { get; set; }
    }
}
