using Microsoft.Extensions.DependencyInjection;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Providers.Graph;
using Synigo.OneApi.Providers.Products;
using Synigo.OneApi.Providers.Products.Options;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace Synigo.OneApi.Providers.Extensions
{
    /// <summary>
    /// Service collection extension methods for providers.
    /// </summary>
    public static class ServiceCollectionProviderExtensions
    {
        /// <summary>
        /// Adds a singleton Afas provider service of the type specified in <typeparamref name="T1"/> with an implementation
        /// specified in <typeparamref name="T2"/> to the <see cref="IServiceCollection"/> and automatically
        /// sets up an HTTP client using the specified <paramref name="configureOptions"/> including the proper
        /// encoding for Afas.
        /// </summary>
        /// <typeparam name="T1">The type of the service to add.</typeparam>
        /// <typeparam name="T2">The type of the implementation to use.</typeparam>
        /// <param name="services">The instance of <see cref="IServiceCollection"/> to add the new services to.</param>
        /// <param name="configureOptions">The Afas options which are applied to the HTTP client.</param>
        /// <returns>A reference to this instance after the Afas provider has been setup.</returns>
        public static IServiceCollection AddAfasProvider<T1, T2>(this IServiceCollection services, Action<AfasProviderOptions> configureOptions)
            where T1 : IAfasProvider 
            where T2 : AbstractProductProvider
        {
            // Create options based on user input
            var optionsInstance = new AfasProviderOptions();
            configureOptions.Invoke(optionsInstance);

            // Add named HttpClient using options defined in options object
            services.AddHttpClient(optionsInstance.HttpClientName, client =>
            {
                client.BaseAddress = new Uri(optionsInstance.BaseAddress);
                var tokenBytes = Encoding.UTF8.GetBytes(optionsInstance.AuthToken);
                var encodedToken = Convert.ToBase64String(tokenBytes);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(optionsInstance.AuthHeader, encodedToken);
            });

            // Create singleton instance of specified provider type
            services.AddSingleton(typeof(T1), typeof(T2));

            return services;
        }

        /// <summary>
        /// Adds a scoped graph provider service of the type specified in <typeparamref name="T1"/> with an implementation
        /// specified in <typeparamref name="T2"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddGraphProvider<T1, T2>(this IServiceCollection services)
            where T1 : IGraphProvider
            where T2 : AbstractGraphProvider
        {
            // Add the graph provider.
            services.AddScoped(typeof(T1), typeof(T2));

            return services;
        }
    }
}
