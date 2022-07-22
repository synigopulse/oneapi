using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Implement this interface to create product APIs that require HTTP requests.
    /// </summary>
    public interface IProductProvider
    {
        /// <summary>
        /// Performs a GET request on the specified uri and converts the message content to a string.
        /// </summary>
        /// <param name="uri">The specified uri to perform the GET request on.</param>
        /// <param name="cancellationToken">The cancellation token to use for this specified request.</param>
        /// <returns>A string containing the message content of the GET request.</returns>
        Task<string> GetAsync(string uri, CancellationToken cancellationToken = default);
        /// <summary>
        /// Performs a GET request on the specified uri and converts the json message content to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The object type to convert the json message content to.</typeparam>
        /// <param name="uri">The specified uri to perform the GET request on.</param>
        /// <param name="options">The options to use when deserializing the json message content.</param>
        /// <param name="cancellationToken">The cancellation token to use for this specified request.</param>
        /// <returns>An object of type <typeparamref name="T"/> containing the message content of the GET request.</returns>
        Task<T> GetAsync<T>(string uri, JsonSerializerOptions options = null, CancellationToken cancellationToken = default);
    }
}
