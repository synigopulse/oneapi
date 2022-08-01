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
        internal OneApiDevelopmentSettings DevelopmentSettings { get; private set; } = new OneApiDevelopmentSettings();
        /// <summary>
        /// Contains the settings used in the production environment.
        /// </summary>
        internal OneApiProductionSettings ProductionSettings { get; private set; } = new OneApiProductionSettings();
        /// <summary>
        /// Contains the general settings such as CORS, HTTPS redirection and routing.
        /// </summary>
        internal OneApiGeneralSettings GeneralSettings { get; private set; } = new OneApiGeneralSettings();
        /// <summary>
        /// Contains the security settings such as Authentication and Authorization.
        /// </summary>
        internal OneApiSecuritySettings SecuritySettings { get; private set; } = new OneApiSecuritySettings();
        /// <summary>
        /// Contains the swagger settings such as enabling swagger or its UI.
        /// </summary>
        internal OneApiSwaggerSettings SwaggerSettings { get; private set; } = new OneApiSwaggerSettings();
        /// <summary>
        /// Contains the endpoint settings such as controlling mapping and healthcheck mapping.
        /// </summary>
        internal OneApiEndpointSettings EndpointSettings { get; private set; } = new OneApiEndpointSettings();

        internal OneApiSettings()
        {
            // public access has been revoked, developers will have to use
            // extension methods to modify the settings.
        }
    }
}
