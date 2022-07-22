using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Core.WebApi.Settings
{
    /// <summary>
    /// A collection of OpenApi security settings which can be configured during startup.
    /// </summary>
    public class OpenApiSecuritySettings : IOneApiSettings
    {
        /// <summary>
        /// Whether to enable authentication middleware or not.
        /// <para>
        /// Default value: <see langword="true"/>
        /// </para>
        /// </summary>
        public bool EnableAuthentication { get; set; } = true;
        /// <summary>
        /// Whether to enable authorization middleware or not.
        /// <para>
        /// Default value: <see langword="true"/>
        /// </para>
        /// </summary>
        public bool EnableAuthorization { get; set; } = true;
    }
}
