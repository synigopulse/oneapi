using Microsoft.Extensions.DependencyInjection;
using Synigo.OneApi.Core.Functions.Middleware;

namespace Synigo.OneApi.Core.Functions.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Add this to service configuration to use our base implementation <see cref="GenerateHttpResponseData"/>
        /// of <see cref="IGenerateHttpResponseData"/> for middlware exception handeling <see cref="ExceptionHandlelingMiddleware"/>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection UseOneApiGenerateHttpResponseData(this IServiceCollection services)
        {
            services.AddSingleton<IGenerateHttpResponseData, GenerateHttpResponseData>();

            return services;
        }

        public static IServiceCollection UseOneApiAuthenthicationProvider(this IServiceCollection services)
        {
            services.AddSingleton<IAuthenthicationProvider, AzureAdAuthenthicationProvider>();

            return services;
        }
    }
}
