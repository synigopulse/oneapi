using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Core.WebApi.Settings
{
    /// <summary>
    /// A collection of OpenApi endpoint settings which can be configured during startup.
    /// </summary>
    public class OpenApiEndpointSettings : IOneApiSettings
    {
        /// <summary>
        /// Whether to enable the endpoint middleware or not.
        /// <para>
        /// Default value: <see langword="true"/>
        /// </para>
        /// </summary>
        public bool EnableEndpoints { get; set; } = true;
        /// <summary>
        /// Whether to map controllers to the endpoint middleware or not.
        /// <para>
        /// Default value: <see langword="true"/>
        /// </para>
        /// </summary>
        public bool EnableControllerMapping { get; set; } = true;
        /// <summary>
        /// Whether to map health checks to the endpoint middleware or not.
        /// <para>
        /// Default value: <see langword="true" />
        /// </para>
        /// </summary>
        public bool EnableHealthCheckMapping { get; set; } = true;
        /// <summary>
        /// The pattern to use for the health check middleware if <see cref="EnableHealthCheckMapping"/> is set to true.
        /// <para>
        /// Default value: "health"
        /// </para>
        /// </summary>
        public string HealthCheckPattern { get; set; } = "health";
    }
}
