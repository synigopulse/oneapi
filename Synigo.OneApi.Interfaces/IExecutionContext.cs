using System.Collections.Generic;
using Synigo.OneApi.Model;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// This context should be passed, or accessible to there where the logic is executed.
    /// It provides access to the environmant (caching, logging, config, etc) and
    /// exposes the parameters and context for this specific "logic execution"
    /// </summary>
    public interface IExecutionContext
    {
        /// <summary>
        /// Get a reference to the current execution context.
        /// </summary>
        public ICurrent Current { get; set; }

        /// <summary>
        /// Get an implementation of <see cref="ICacheProvider"/>
        /// </summary>
        public ICacheProvider CacheProvider { get; }

        /// <summary>
        /// Get an implementation of <see cref="IConfigurationProvider"/>
        /// </summary>
        public IConfigurationProvider ConfigurationProvider { get; }

        /// <summary>
        /// Get an implementation of <see cref="ILogProvider"/>
        /// </summary>
        public ILogProvider LogProvider { get; }

        /// <summary>
        /// Get a list of validation mechanisms to validate the current request.
        /// </summary>
        public List<IRequestValidationProvider> Validators { get; }

        /// <summary>
        /// Get an implementation of <see cref="BaseEntityProvider{T}"/>
        /// </summary>
        /// <typeparam name="TEntityProviderType">Get an entity provider for this type of storage</typeparam>
        /// <typeparam name="TForType">And for a subclass of <see cref="AbstractEntity"/></typeparam>
        /// <returns>The requested instance of <see cref="IBaseEntityProvider{T}"/> or null if not registered</returns>
        public TEntityProviderType GetEntityProvider<TEntityProviderType,TForType>() where TForType : AbstractEntity;
    }
}