using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Synigo.OneAPi.Core.Logic;

namespace Synigo.OneAPi.Core.Extensions
{
    /// <summary>
    /// Extension to get a reference to the One Api Builder
    /// </summary>
    public static class HostBuilderExtension
    {
        /// <summary>
        /// Get a reference to the One API Builder to start configuring IOC en DI for One API
        /// </summary>
        /// <param name="builder">An implementation of <see cref="IFunctionsHostBuilder"/></param>
        /// <returns>The OneAPiBuilder, to configure your One API</returns>
        public static OneApiBuilder AddOneApi (this IFunctionsHostBuilder builder)
        {
            return new OneApiBuilder(builder); 
        }
    }
}
