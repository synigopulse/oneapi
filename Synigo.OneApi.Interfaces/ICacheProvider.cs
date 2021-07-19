using System;
using System.Threading.Tasks;
using Synigo.OneApi.Model.Exceptions;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Provider which should be implemented to create a caching mechanism, e.g. Memory cache or Redis Cache
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// Add an item to the cache for a certain duration
        /// </summary>
        /// <typeparam name="T">The type of the item to add</typeparam>
        /// <param name="cacheKey">The key (identifier) of the item</param>
        /// <param name="item">The item to add</param>
        /// <param name="duration">The <see cref="TimeSpan"/> duration of the cache period</param>
        /// <param name="shouldEncrypt">Store the serialized item in an encrypted way</param>
        /// <exception cref="CacheException">When somethings goes wrong</exception>
        /// <exception cref="SerializationException">When serializing the object goes wrong</exception>
        public Task PutAsync(string cacheKey, object item, TimeSpan duration, bool shouldEncrypt = false);

        /// <summary>
        /// Get an item from the cache
        /// </summary>
        /// <typeparam name="T">The type of the item to get</typeparam>
        /// <param name="cacheKey">The key (identifier) of the item</param>
        /// <param name="decrypted">The item was encrypted when cached, so it must be decrypted</param>
        /// <returns>The item, or null if it does not exist</returns>
        /// <exception cref="CacheException">When somethings goes wrong</exception>
        /// <exception cref="SerializationException">When deserializing the object goes wrong</exception>
        public Task<T> GetAsync<T>(string cacheKey, bool decrypt = false);

        /// <summary>
        /// Clear all items from the cache
        /// </summary>
        /// <exception cref="CacheException">When somethings goes wrong</exception>
        public Task ClearAsync();
    }
}
