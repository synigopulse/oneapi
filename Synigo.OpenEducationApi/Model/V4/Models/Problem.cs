using System.Net;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// A system message including the error code and an explanation 
    /// </summary>
    public class Problem
    {
        /// <summary>
        /// The HTTP status code
        /// </summary>
        /// <example>404</example>
        [JsonPropertyName("status")]
        public HttpStatusCode Status { get; set; }

        /// <summary>
        /// A short, human-readable summary of the problem type
        /// </summary>
        /// <example>Resource not found</example>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        ///  A human-readable explanation specific to this occurrence of the problem
        /// </summary>
        [JsonPropertyName("detail")]
        public string Datail { get; set; }
    }
}
