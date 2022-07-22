using Synigo.OneApi.Core.WebApi.Settings;

namespace Synigo.OneApi.Core.WebApi
{
    /// <summary>
    /// An implementation which contains all the relevant OpenApi settings that can be configured during startup.
    /// </summary>
    public class OneApiSettings
    {
        /// <summary>
        /// Contains the settings used in the development environment.
        /// </summary>
        internal OpenApiDevelopmentSettings DevelopmentSettings { get; private set; } = new OpenApiDevelopmentSettings();
        /// <summary>
        /// Contains the settings used in the production environment.
        /// </summary>
        internal OpenApiProductionSettings ProductionSettings { get; private set; } = new OpenApiProductionSettings();
        /// <summary>
        /// Contains the general settings such as CORS, HTTPS redirection and routing.
        /// </summary>
        internal OpenApiGeneralSettings GeneralSettings { get; private set; } = new OpenApiGeneralSettings();
        /// <summary>
        /// Contains the security settings such as Authentication and Authorization.
        /// </summary>
        internal OpenApiSecuritySettings SecuritySettings { get; private set; } = new OpenApiSecuritySettings();
        /// <summary>
        /// Contains the swagger settings such as enabling swagger or its UI.
        /// </summary>
        internal OpenApiSwaggerSettings SwaggerSettings { get; private set; } = new OpenApiSwaggerSettings();
        /// <summary>
        /// Contains the endpoint settings such as controlling mapping and healthcheck mapping.
        /// </summary>
        internal OpenApiEndpointSettings EndpointSettings { get; private set; } = new OpenApiEndpointSettings();

        internal OneApiSettings()
        {
            // public access has been revoked, developers will have to use
            // extension methods to modify the settings.
        }
    }
}
