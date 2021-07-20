using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Synigo.OneApi.Model;
using Synigo.OneApi.Model.Exceptions;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Interface for communicating with Blobstorage
    /// </summary>
    /// <typeparam name="T">The type of the entity, must be a subclass of <see cref="AbstractEntity"/></typeparam>
    public interface IBlobStorageProvider<T> where T : AbstractEntity, IBaseEntityProvider<T>
    {
        /// <summary>
        /// Delete a blob by its name
        /// </summary>
        /// <param name="blobName">The name of the blob</param>
        public Task DeleteAsync(string blobName);

        /// <summary>
        /// Retrieve an instance of an object, stored in blobstorage
        /// </summary>
        /// <param name="blobName">The name of the blob</param>
        /// <returns>An instance of an object</returns>
        /// <exception cref="SerializationException">When deserialization goes wrong</exception>
        public Task<T> GetAsync(string blobName);

        /// <summary>
        /// Get a stream reference to a blob
        /// </summary>
        /// <param name="blobName">The name of the blob</param>
        /// <returns>A stream ref to the blob</returns>
        public Task<Stream> GetStreamAsync(string blobName);

        /// <summary>
        /// List all blobs in a blob folder
        /// </summary>
        /// <param name="blobFolderName">The name of the folder</param>
        /// <returns>A list of all blobs in this folder</returns>
        public Task<List<string>> ListAsync(string blobFolderName);

        /// <summary>
        /// Store an item in the blobstorage
        /// </summary>
        /// <param name="blobName">The name of the blob</param>
        /// <param name="item">The item to store</param>
        /// <returns>The item</returns>
        /// <exception cref="SerializationException">When serialization goes wrong</exception>
        public Task<T> StoreAsync(string blobName, T item);

    }
}
