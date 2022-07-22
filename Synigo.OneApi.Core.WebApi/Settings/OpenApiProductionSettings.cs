using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Core.WebApi.Settings
{
    /// <summary>
    /// A collection of OpenApi production settings which can be configured during startup.
    /// </summary>
    public class OpenApiProductionSettings : IOneApiSettings
    {
        /// <summary>
        /// Whether to enable the exception handler or not.
        /// <para>
        /// Default value: <see langword="true"/>
        /// </para>
        /// </summary>
        public bool EnableExceptionHandler { get; set; } = true;
        /// <summary>
        /// The path on which the exception handling will occur.
        /// <para>
        /// Default value: "/Error"
        /// </para>
        /// </summary>
        public string ErrorHandlingPath { get; set; } = "/Error";
        /// <summary>
        /// Whether to enable the Strict-Transport-Security header or not
        /// <para>
        /// Default value: <see langword="true"/>
        /// </para>
        /// </summary>
        public bool EnableHosts { get; set; } = true;
    }
}
