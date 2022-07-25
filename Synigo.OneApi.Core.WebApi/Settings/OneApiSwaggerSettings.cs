using System;
using Swashbuckle.AspNetCore.SwaggerUI;
using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Core.WebApi.Settings
{
    /// <summary>
    /// A collection of OpenApi Swagger settings which can be configured during startup.
    /// </summary>
    public class OneApiSwaggerSettings : IOneApiSettings
    {
        /// <summary>
        /// Whether to enable the swagger middleware or not.
        /// Default value: <see langword="true"/>
        /// </summary>
        public bool EnableSwagger { get; set; } = true;
        /// <summary>
        /// Whether to enable the swagger UI middleware or not.
        /// Default value: <see langword="false"/>
        /// </summary>
        public bool EnableSwaggerUI { get; set; } = false;
        /// <summary>
        /// The Swagger UI options to use when <see cref="EnableSwaggerUI"/> is set to true.
        /// <para>
        /// Default value: null
        /// </para>
        /// </summary>
        public Action<SwaggerUIOptions>? SwaggerUIOptions { get; set; } = null;
    }
}
