using Synigo.OneApi.Interfaces;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Synigo.OneApi.Core.WebApi.Settings
{
    /// <summary>
    /// A collection of OpenApi endpoint settings which can be configured during startup.
    /// </summary>
    public class OneApiEndpointSettings : IOneApiSettings
    {
        /// <summary>
        /// Whether to enable the endpoint middleware or not.
        /// Default value: <see langword="true"/>
        /// </summary>
        public bool EnableEndpoints { get; set; } = true;
        /// <summary>
        /// Whether to map controllers to the endpoint middleware or not.
        /// Default value: <see langword="true"/>
        /// </summary>
        public bool EnableControllerMapping { get; set; } = true;
        /// <summary>
        /// Whether to map health checks to the endpoint middleware or not.
        /// Default value: <see langword="true" />
        /// </summary>
        public bool EnableHealthCheckMapping { get; set; } = true;
        /// <summary>
        /// The pattern to use for the health check middleware if <see cref="EnableHealthCheckMapping"/> is set to true.
        /// Default value: "health"
        /// </summary>
        public string HealthCheckPattern { get; set; } = "health";
        /// <summary>
        /// Additional health check settings. These are only used if <see cref="EnableHealthCheckMapping"/> is set to true.
        /// Default value: <see langword="null"/>
        /// </summary>
        public HealthCheckOptions? HealthCheckOptions { get; set; } = null;
    }
}
