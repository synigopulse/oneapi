using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Synigo.OneApi.Model;
using Synigo.OneApi.Model.Exceptions;

namespace Synigo.OneApi.Providers.Storage
{
    public class BlobStorageProvider<T1> where T1 : AbstractEntity
    {
        private readonly BlobContainerClient _blobClient;
        public BlobStorageProvider(string connectionString, string containerName)
        {
            var options = new BlobClientOptions();
            options.Retry.MaxRetries = 1;
            _blobClient = new BlobContainerClient(connectionString, containerName, options);
        }

        public async Task DeleteAsync(string blobName)
        {
            await _blobClient.DeleteBlobIfExistsAsync(blobName);
        }

        public async Task<T1> GetAsync(string blobName)
        {
            using var memoryStream = await GetStreamAsync(blobName);

            if (memoryStream == null)
            {
                return default;
            }

            try
            {
                var result = await JsonSerializer.DeserializeAsync<T1>(memoryStream);
                return result;
            }
            catch (Exception ex)
            {
                throw new SerializationException($"Failed to deserialize {blobName}", ex);
            }
        }

        public async Task<Stream> GetStreamAsync(string blobName)
        {
            try
            {
                var client = _blobClient.GetBlockBlobClient(blobName);
                using var memoryStream = new MemoryStream();
                await client.DownloadToAsync(memoryStream);
                return memoryStream;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<string>> ListAsync(string blobFolderName)
        {
            var blobs = _blobClient.GetBlobsAsync(prefix: blobFolderName);
            var folders = new List<string>();
            string continuationToken = null;

            try
            {
                await foreach (var page in blobs.AsPages(continuationToken))
                {
                    continuationToken = page.ContinuationToken;
                    folders.AddRange(page.Values.Select(i => i.Name));
                }
            } catch{
                // intentionally do nothing
            }

            return folders;
        }

        public async Task<T1> StoreAsync(string blobName, T1 item)
        {
            var client = _blobClient.GetBlobClient(blobName);
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, item);
            await client.UploadAsync(stream);
            return item;
        }
    }
}
