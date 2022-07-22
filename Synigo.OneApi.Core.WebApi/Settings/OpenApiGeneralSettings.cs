using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Core.WebApi.Settings
{
    /// <summary>
    /// A collection of OpenApi general settings which can be configured during startup.
    /// </summary>
    public class OpenApiGeneralSettings : IOneApiSettings
    {
        /// <summary>
        /// Whether to enable cross domain requests or not.
        /// <para>
        /// Default value: <see langword="true"/>
        /// </para>
        /// </summary>
        public bool EnableCors { get; set; } = true;
        /// <summary>
        /// The policy name to use for the cross domain requests middleware if <see cref="EnableCors"/> is set to true.
        /// <para>
        /// Default value: "globalCorsPolicy"
        /// </para>
        /// </summary>
        public string CorsPolicyName { get; set; } = "globalCorsPolicy";
        /// <summary>
        /// Whether to redirect HTTP requests to HTTPS or not.
        /// <para>
        /// Default value: <see langword="true"/>
        /// </para>
        /// </summary>
        public bool EnableHttpsRedirection { get; set; } = true;
        /// <summary>
        /// Whether to enable static file serving for the current request path or not.
        /// <para>
        /// Default value: <see langword="true"/>
        /// </para>
        /// </summary>
        public bool EnableStaticFileServing { get; set; } = true;
        /// <summary>
        /// Whether to enable the routing middleware or not.
        /// <para>
        /// Default value: <see langword="true"/>
        /// </para>
        /// </summary>
        public bool EnableRouting { get; set; } = true;
    }
}
