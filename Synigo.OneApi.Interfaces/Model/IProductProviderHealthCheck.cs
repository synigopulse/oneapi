using System.Collections.Generic;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Synigo.OneApi.Interfaces.Model
{
    /// <summary>
    /// Implement this interface to create product provider health checks.
    /// </summary>
    public interface IProductProviderHealthCheck : IHealthCheck
    {
        /// <summary>
        /// The name of the health check.
        /// </summary>
        public string HealthCheckName { get; }
        /// <summary>
        /// The tags of the health check.
        /// </summary>
        public IEnumerable<string> Tags { get; }
        /// <summary>
        /// The default failure status to use.
        /// </summary>
        public HealthStatus DefaultFailureStatus { get; }
    }
}
