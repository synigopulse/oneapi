using Synigo.OneApi.Interfaces;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System;

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
        public Action<HealthCheckOptions>? HealthCheckOptions { get; set; } = null;
        /// <summary>
        /// One or more permitted hosts for the health check endpoint.
        /// Default value: <see cref="string.Empty"/>
        /// </summary>
        public string[]? HealthCheckRequireHosts { get; set; } = null;
        /// <summary>
        /// Whether to require authorization to access the health check endpoint.
        /// </summary>
        public bool HealthCheckRequireAuthorization { get; set; } = false;
        /// <summary>
        /// One or more permitted policy names to use when <see cref="HealthCheckRequireAuthorization"/> is set to true.
        /// </summary>
        public string[]? HealthCheckAuthorizationPolicyNames { get; set; } = null;
    }
}
