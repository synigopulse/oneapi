using System.Collections.Generic;
using System.Threading.Tasks;
using Synigo.OneApi.Model;
using Synigo.OneApi.Model.Exceptions;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Super interface which should be overriden by interfaces which
    /// are able to perform CRUD actions on any implementation of <see cref="AbstractEntity"/>, e.g. blob or table storage, or SQL
    /// </summary>
    /// <typeparam name="T">The type of the entity</typeparam>
    public interface IBaseEntityProvider<T> where T: AbstractEntity
    {
        /// <summary>
        /// Get single instance of <see cref="T"/>
        /// </summary>
        /// <param name="Id">The id of the <see cref="AbstractEntity"/></param>
        /// <returns>The <see cref="AbstractEntity"/> if found, otherwise null</returns>
        /// <exception cref="EntityStorageException">When anything goes wrong</exception>
        public Task<T> GetAsync(string Id);

        /// <summary>
        /// Store a single instance of T
        /// </summary>
        /// <param name="item">The item to store</param>
        /// <returns>The stored item if successful, maybe with a generated Id</returns>
        /// <exception cref="EntityStorageException">When anything goes wrong</exception>
        public Task<T> StoreAsync(T item);

        /// <summary>
        /// Store a list of T
        /// </summary>
        /// <param name="item">The items to store</param>
        /// <returns>The stored items if successful, maybe with generated Ids</returns>
        /// <exception cref="EntityStorageException">When anything goes wrong</exception>
        public Task<List<T>> StorAsync(List<T> items);

        /// <summary>
        /// Delete an instance of <see cref="T"/>
        /// </summary>
        /// <param name="id">The id of the item to delete</param>
        /// <exception cref="EntityStorageException">When anything goes wrong</exception>
        public Task DeleteAsync(string id);
    }
}
