using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Core.WebApi.Settings
{
    /// <summary>
    /// A collection of OpenApi production settings which can be configured during startup.
    /// </summary>
    public class OneApiProductionSettings : IOneApiSettings
    {
        /// <summary>
        /// Whether to enable the exception handler or not.
        /// Default value: <see langword="true"/>
        /// </summary>
        public bool EnableExceptionHandler { get; set; } = true;
        /// <summary>
        /// The path on which the exception handling will occur.
        /// Default value: "/Error"
        /// </summary>
        public string ErrorHandlingPath { get; set; } = "/Error";
        /// <summary>
        /// Whether to enable the Strict-Transport-Security header or not
        /// Default value: <see langword="true"/>
        /// </summary>
        public bool EnableHosts { get; set; } = true;
    }
}
