using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using Synigo.OneApi.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.IO;
using System.Collections.Generic;

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
        /// The name of this health check.
        /// </summary>
        public abstract string HealthCheckName { get; }

        /// <summary>
        /// The tags of this health check.
        /// Default value contains: <c>all</c>
        /// </summary>
        public virtual IEnumerable<string> Tags { get; } = new string[]
        {
            "all"
        };

        /// <summary>
        /// The default failure status of this health check.
        /// Default value: <see cref="HealthStatus.Unhealthy"/>
        /// </summary>
        public virtual HealthStatus DefaultFailureStatus { get; } = HealthStatus.Unhealthy;

        /// <summary>
        /// Performs a health check on the specified <see cref="HealthCheckContext"/>. This method sould be overriden
        /// and should perform the relevant health checks for this provider.
        /// </summary>
        /// <param name="context">The context on which to perform the health checks.</param>
        /// <param name="cancellationToken">The cancellation token to use for this </param>
        /// <returns>A <see cref="HealthCheckResult"/> containing the health status for this context -- or if this method has not been overridden, 
        /// a <see cref="HealthStatus.Healthy"/> result which states that no health check has been provided for provider.</returns>
        public virtual Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Healthy($"No health check provided for type {GetType()}."));
        }

        /// <summary>
        /// Performs a GET request on the specified uri and returns a stream of the message content
        /// </summary>
        /// <param name="uri">The specified uri to perform the GET request on.</param>
        /// <param name="cancellationToken">The cancellation token to use for this request.</param>
        /// <returns>A stream containing the message content of the GET request or an exception if something went wrong.</returns>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="TaskCanceledException"/>
        /// <exception cref="Exception"/>
        public async Task<Stream> GetAsync(string uri, CancellationToken cancellationToken = default)
        {
            var message = await Client.GetAsync(uri, cancellationToken);

            message.EnsureSuccessStatusCode();

            return await message.Content.ReadAsStreamAsync(cancellationToken);
        }

        /// <summary>
        /// Performs a GET request on the specified uri and converts the json message content to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The object type to convert the json message content to.</typeparam>
        /// <param name="uri">The specified uri to perform the GET request on.</param>
        /// <param name="options">The options to use when deserializing the json message content.</param>
        /// <param name="cancellationToken">The cancellation token to use for this request.</param>
        /// <returns>An object of type <typeparamref name="T"/> containing the message content of the GET request or an exception if something went wrong.</returns>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="TaskCanceledException"/>
        /// <exception cref="JsonException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="Exception"/>
        public async Task<T?> GetAsync<T>(string uri, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
        {
            var message = await Client.GetAsync(uri, cancellationToken);

            message.EnsureSuccessStatusCode();

            using var stream = await message.Content.ReadAsStreamAsync(cancellationToken);

            if (stream.Length == 0)
            {
                return default;
            }

            var result = await JsonSerializer.DeserializeAsync<T>(stream, options, cancellationToken);

            if (result == null)
            {
                throw new Exception($"Unable to convert message content to object of type: {typeof(T)}.");
            }

            return result;
        }
    }
}
