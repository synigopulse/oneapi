using System.Collections.Generic;
using System.Threading.Tasks;
using Synigo.OneApi.Model;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Interface for communicating using SQL. Basically the implementation of this interface
    /// needs to be smart enough to bind SQL params to SQL using just the string SQL statement and the provided, maybe dynamic object
    /// Interface is especially written for Dapper
    /// </summary>
    /// <typeparam name="T">The type of the entity, must be a subclass of <see cref="AbstractEntity"/></typeparam>
    public interface ISqlProvider<T> :IBaseEntityProvider<T> where T : AbstractEntity
    {
        /// <summary>
        /// Get single instance of <see cref="T"/>
        /// </summary>
        /// <param name="sql">The SQL query to Execute</param>
        /// <param name="param">The params which are inserted in the provided SQL statement</param>
        /// <returns>The <see cref="AbstractEntity"/> if found, otherwise null</returns>
        /// <exception cref="EntityStorageException">When anything goes wrong</exception>
        public Task<T> GetAsync(string sql, object param);

        /// <summary>
        /// Get a list of T<see cref="T"/>
        /// </summary>
        /// <param name="sql">The SQL query to Execute</param>
        /// <param name="param">The params which are inserted in the provided SQL statement</param>
        /// <returns>The <see cref="AbstractEntity"/> if found, otherwise null</returns>
        /// <exception cref="EntityStorageException">When anything goes wrong</exception>
        public Task<IEnumerable<T>> GetListAsync(string sql, object param);

        /// <summary>
        /// Store a single instance of T
        /// </summary>
        /// <param name="sql">The SQL query to Execute</param>
        /// <param name="item">The item to store</param>
        /// <returns>The stored item if successful, maybe with a generated Id</returns>
        /// <exception cref="EntityStorageException">When anything goes wrong</exception>
        public Task<T> StoreAsync(string sql, T item);

        /// <summary>
        /// Store a list of T
        /// </summary>
        /// <param name="sql">The SQL query to Execute</param>
        /// <param name="items">A list of items to store</param>
        /// <returns>The stored items if successful, maybe with generated Ids</returns>
        /// <exception cref="EntityStorageException">When anything goes wrong</exception>
        public Task<List<T>> StoreAsync(string sql, List<T> items);

        /// <summary>
        /// Delete an instance of <see cref="T"/>
        /// </summary>
        /// <param name="sql">The SQL query to Execute</param>
        /// <param name="param">The params which are inserted in the provided SQL statement</param>
        /// <exception cref="EntityStorageException">When anything goes wrong</exception>
        public Task DeleteAsync(string sql, object param);
    }
}
