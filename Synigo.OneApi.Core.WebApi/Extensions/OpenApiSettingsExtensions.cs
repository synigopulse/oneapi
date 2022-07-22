using System;
using Synigo.OneApi.Core.WebApi.Settings;
using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Core.WebApi.Extensions
{
    /// <summary>
    /// OpenApi extension methods for configurable settings.
    /// </summary>
    public static class OpenApiSettingsExtensions
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
                configuration.Invoke((T)(object)settings.DevelopmentSettings);
            } 
            else if (type == settings.ProductionSettings.GetType())
            {
                configuration.Invoke((T)(object)settings.ProductionSettings);
            }
            else if (type == settings.GeneralSettings.GetType())
            {
                configuration.Invoke((T)(object)settings.GeneralSettings);
            }
            else if (type == settings.SecuritySettings.GetType())
            {
                configuration.Invoke((T)(object)settings.SecuritySettings);
            }
            else if (type == settings.SwaggerSettings.GetType())
            {
                configuration.Invoke((T)(object)settings.SwaggerSettings);
            }
            else if (type == settings.EndpointSettings.GetType())
            {
                configuration.Invoke((T)(object)settings.EndpointSettings);
            }

            return settings;
        }
    }
}
