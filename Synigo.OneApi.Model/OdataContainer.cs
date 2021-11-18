using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model
{
    public class OdataContainer<T>
    {
        /// <summary>
        /// Get or set the type, this is used to determine, how to convert this model into the viewmodel
        /// in the synigo pulse front end.
        /// </summary>
        [JsonPropertyName("@odata.type")]
        public string Type { get; set; }

        /// <summary>
        /// Get or set the nextlink. If you want to return a paged collection, use this value
        /// to set the link to use, to obtain the next page.
        /// </summary>
        [JsonPropertyName("@odata.nextLink")]
        public string NextLink { get; set; } 

        /// <summary>
        /// Get or set the count. Besides paging <see cref="OdataContainer{T}.NextLink"/> you can also
        /// set the count. This way we are able to implement paging in the front end. 
        /// </summary>
        [JsonPropertyName("@odata.count")]
        public int? Count { get; set; }

        /// <summary>
        /// In order to make full use of caching, you can set the ETag value. The front end is able to determine if this
        /// request with the same etag is available at front end side, UI uses that data, which greatly improves perceived
        /// performance.
        /// </summary>
        [JsonPropertyName("@odata.etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Get or set the actual value for this OData container
        /// </summary>
        [JsonPropertyName("value")]
        public T Value { get; set; }
    }
}
