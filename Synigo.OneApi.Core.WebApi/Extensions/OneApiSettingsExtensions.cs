using System;
using Synigo.OneApi.Core.WebApi.Settings;
using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Core.WebApi.Extensions
{
    /// <summary>
    /// OpenApi extension methods for configurable settings.
    /// </summary>
    public static class OneApiSettingsExtensions
    {
        /// <summary>
        /// Configures the <typeparamref name="T"/> of the current <see cref="OneApiSettings"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of settings to configure.</typeparam>
        /// <param name="settings">The one api settings instance to configure.</param>
        /// <param name="configureSettings">The configuration settings to apply to the <see cref="OneApiSettings"/> instance.</param>
        /// <returns>The <see cref="OneApiSettings"/> instance with the modified settings.</returns>
        public static OneApiSettings Configure<T>(this OneApiSettings settings, Action<T> configuration)
            where T : IOneApiSettings
        {
            var type = typeof(T);

            if (type == settings.DevelopmentSettings.GetType())
            {
                settings.ConfigureDevelopmentSettings((Action<OneApiDevelopmentSettings>)(object)configuration);
            } 
            else if (type == settings.ProductionSettings.GetType())
            {
                settings.ConfigureProductionSettings((Action<OneApiProductionSettings>)(object)configuration);
            }
            else if (type == settings.GeneralSettings.GetType())
            {
                settings.ConfigureGeneralSettings((Action<OneApiGeneralSettings>)(object)configuration);
            }
            else if (type == settings.SecuritySettings.GetType())
            {
                settings.ConfigureSecuritySettings((Action<OneApiSecuritySettings>)(object)configuration);
            }
            else if (type == settings.SwaggerSettings.GetType())
            {
                settings.ConfigureSwaggerSettings((Action<OneApiSwaggerSettings>)(object)configuration);
            }
            else if (type == settings.EndpointSettings.GetType())
            {
                settings.ConfigureEndpointSettings((Action<OneApiEndpointSettings>)(object)configuration);
            }

            return settings;
        }

        /// <summary>
        /// Configures the development settings of the current <see cref="OneApiSettings"/> instance.
        /// </summary>
        /// <param name="settings">The one api settings instance to configure.</param>
        /// <param name="configuration">The development configuration settings to apply to the <see cref="OneApiSettings"/> instance.</param>
        /// <returns>The <see cref="OneApiSettings"/> instance with the modified development settings.</returns>
        public static OneApiSettings ConfigureDevelopmentSettings(this OneApiSettings settings, Action<OneApiDevelopmentSettings> configuration)
        {
            configuration.Invoke(settings.DevelopmentSettings);
            return settings;
        }

        /// <summary>
        /// Configures the production settings of the current <see cref="OneApiSettings"/> instance.
        /// </summary>
        /// <param name="settings">The one api settings instance to configure.</param>
        /// <param name="configuration">The production configuration settings to apply to the <see cref="OneApiSettings"/> instance.</param>
        /// <returns>The <see cref="OneApiSettings"/> instance with the modified production settings.</returns>
        public static OneApiSettings ConfigureProductionSettings(this OneApiSettings settings, Action<OneApiProductionSettings> configuration)
        {
            configuration.Invoke(settings.ProductionSettings);
            return settings;
        }

        /// <summary>
        /// Configures the general settings of the current <see cref="OneApiSettings"/> instance.
        /// </summary>
        /// <param name="settings">The one api settings instance to configure.</param>
        /// <param name="configuration">The general configuration settings to apply to the <see cref="OneApiSettings"/> instance.</param>
        /// <returns>The <see cref="OneApiSettings"/> instance with the modified general settings.</returns>
        public static OneApiSettings ConfigureGeneralSettings(this OneApiSettings settings, Action<OneApiGeneralSettings> configuration)
        {
            configuration.Invoke(settings.GeneralSettings);
            return settings;
        }

        /// <summary>
        /// Configures the security settings of the current <see cref="OneApiSettings"/> instance.
        /// </summary>
        /// <param name="settings">The one api settings instance to configure.</param>
        /// <param name="configuration">The security configuration settings to apply to the <see cref="OneApiSettings"/> instance.</param>
        /// <returns>The <see cref="OneApiSettings"/> instance with the modified security settings.</returns>
        public static OneApiSettings ConfigureSecuritySettings(this OneApiSettings settings, Action<OneApiSecuritySettings> configuration)
        {
            configuration.Invoke(settings.SecuritySettings);
            return settings;
        }

        /// <summary>
        /// Configures the swagger settings of the current <see cref="OneApiSettings"/> instance.
        /// </summary>
        /// <param name="settings">The one api settings instance to configure.</param>
        /// <param name="configuration">The swagger configuration settings to apply to the <see cref="OneApiSettings"/> instance.</param>
        /// <returns>The <see cref="OneApiSettings"/> instance with the modified swagger settings.</returns>
        public static OneApiSettings ConfigureSwaggerSettings(this OneApiSettings settings, Action<OneApiSwaggerSettings> configuration)
        {
            configuration.Invoke(settings.SwaggerSettings);
            return settings;
        }

        /// <summary>
        /// Configures the endpoint settings of the current <see cref="OneApiSettings"/> instance.
        /// </summary>
        /// <param name="settings">The one api settings instance to configure.</param>
        /// <param name="configuration">The endpoint configuration settings to apply to the <see cref="OneApiSettings"/> instance.</param>
        /// <returns>The <see cref="OneApiSettings"/> instance with the modified endpoint settings.</returns>
        public static OneApiSettings ConfigureEndpointSettings(this OneApiSettings settings, Action<OneApiEndpointSettings> configuration)
        {
            configuration.Invoke(settings.EndpointSettings);
            return settings;
        }
    }
}
