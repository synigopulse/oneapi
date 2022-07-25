using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Synigo.OneApi.Interfaces.Model;
using System.Linq;

namespace Synigo.OneApi.Core.WebApi.Extensions
{
    public static class OneApiHealthCheckExtensions
    {
        /// <summary>
        /// Adds all the instances of type <see cref="IProductProviderHealthCheck"/> to the health check builder.
        /// </summary>
        /// <param name="serviceCollection">The services to retrieve the <see cref="IProductProviderHealthCheck"/> from.</param>
        /// <returns>The <see cref="IServiceCollection"/> containing the new health checks.</returns>
        public static IServiceCollection AddProductProvidersHealthChecks(this IServiceCollection serviceCollection)
        {
            var healthCheckBuilder = serviceCollection.AddHealthChecks();
            var healthCheckServices = serviceCollection.Where(s => s.ServiceType.IsAssignableTo(typeof(IProductProviderHealthCheck))).ToList();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            foreach (var healthCheckService in healthCheckServices)
            {
                var serviceInstance = (IProductProviderHealthCheck) serviceProvider.GetService(healthCheckService.ServiceType);

                if (serviceInstance == null)
                {
                    continue;
                }

                healthCheckBuilder.AddCheck(serviceInstance.HealthCheckName, serviceInstance, serviceInstance.DefaultFailureStatus, serviceInstance.Tags);
            }

            return serviceCollection;
        }
    }
}
