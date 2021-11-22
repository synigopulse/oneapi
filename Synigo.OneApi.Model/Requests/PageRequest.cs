using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Requests
{
    public class PageRequest<T> : IPageRequest
    {
        /// <summary>
        /// Page number
        /// </summary>
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }
 
        /// <summary>
        /// Number of records per page
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// Order params
        /// </summary>
        [JsonPropertyName("sort")]
        public List<string> Sort { get; set; }

        [JsonPropertyName("request")]
        public T Request { get; set; }
    }
}
