using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Providers.Products
{
    /// <summary>
    /// An abstract implementation of a base product provider.
    /// </summary>
    public abstract class AbstractProductProvider : IProductProvider
    {
        /// <summary>
        /// The client used to make the HTTP requests.
        /// </summary>
        protected readonly HttpClient Client;

        public AbstractProductProvider(IHttpClientFactory clientFactory, string clientName)
        {
            Client = clientFactory.CreateClient(clientName);
        }

        /// <summary>
        /// Performs a GET request on the specified uri and converts the message content to a string.
        /// </summary>
        /// <param name="uri">The specified uri to perform the GET request on.</param>
        /// <param name="cancellationToken">The cancellation token to use for this specified request.</param>
        /// <returns>A string containing the message content of the GET request or an exception if something went wrong.</returns>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="TaskCanceledException"/>
        /// <exception cref="Exception"/>
        public async Task<string> GetAsync(string uri, CancellationToken cancellationToken = default)
        {
            var message = await Client.GetAsync(uri, cancellationToken);

            message.EnsureSuccessStatusCode();

            var result = await message.Content.ReadAsStringAsync(cancellationToken);

            if (result == null)
            {
                throw new Exception("Unable to read message content to string");
            }

            return result;
        }

        /// <summary>
        /// Performs a GET request on the specified uri and converts the json message content to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The object type to convert the json message content to.</typeparam>
        /// <param name="uri">The specified uri to perform the GET request on.</param>
        /// <param name="options">The options to use when deserializing the json message content.</param>
        /// <param name="cancellationToken">The cancellation token to use for this specified request.</param>
        /// <returns>An object of type <typeparamref name="T"/> containing the message content of the GET request or an exception if something went wrong.</returns>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="TaskCanceledException"/>
        /// <exception cref="JsonException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="Exception"/>
        public async Task<T> GetAsync<T>(string uri, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            var message = await Client.GetAsync(uri, cancellationToken);

            message.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<T>(await message.Content.ReadAsStreamAsync(cancellationToken), options, cancellationToken);

            if (result == null)
            {
                throw new Exception($"Unable to read message content to {typeof(T)}");
            }

            return result;
        }
    }
}
