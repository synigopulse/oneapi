using Microsoft.AspNetCore.Builder;
using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Core.WebApi.Settings
{
    /// <summary>
    /// A collection of OpenApi development settings which can be configured during startup.
    /// </summary>
    public class OpenApiDevelopmentSettings : IOneApiSettings
    {
        /// <summary>
        /// Whether to enable the developer exception page or not.
        /// <para>
        /// Default value: <see langword="true"/>
        /// </para>
        /// </summary>
        public bool EnableExceptionPage { get; set; } = true;
        /// <summary>
        /// Additional developerr exception page settings.
        /// <para>
        /// Default value: <see langword="null"/>
        /// </para>
        /// </summary>
        public DeveloperExceptionPageOptions ExceptionPageOptions { get; set; } = null;
    }
}
