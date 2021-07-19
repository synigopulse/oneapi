using System.Threading.Tasks;
using Synigo.OneApi.Model.Exceptions;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Interface which should be implemented to get configuration values
    /// </summary>
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Get a configuration value by its key
        /// </summary>
        /// <param name="key"The key of the item></param>
        /// <returns>The value or null if not found</returns>
        /// <exception cref="ConfigurationException">When something goes wrong</exception>
        public Task<string> GetAsync(string key);
    }
}