using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;
using Synigo.OneApi.Common.Extensions;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Model.Exceptions;

namespace Synigo.OneApi.Providers.Cache
{
    public class RedisCacheProvider : ICacheProvider
    {
        private readonly IDatabase _database;
        private readonly Lazy<ConnectionMultiplexer> _connection;

        public RedisCacheProvider(string connectionString)
        {
            _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(connectionString));
            _database = _connection.Value.GetDatabase();
        }

        public async Task ClearAsync()
        {
            try
            {
                var endpoints = _connection.Value.GetEndPoints();
                var server = _connection.Value.GetServer(endpoints.First());
                var keys = server.Keys(_database.Database);

                foreach (var key in keys)
                {
                    await _database.KeyDeleteAsync(key);
                }
            }
            catch (Exception ex)
            {
                throw new CacheException($"Failed to clear cache", ex);
            }
        }

        public async Task<T> GetAsync<T>(string cacheKey, bool shouldDecrypt = false)
        {
            if (string.IsNullOrEmpty(cacheKey))
                return default;

            T item;
            string data;

            try
            {
                string maybeEncryptedData = await _database.StringGetAsync(cacheKey);

                if (string.IsNullOrEmpty(maybeEncryptedData))
                {
                    return default;
                }

                data = Decrypt(maybeEncryptedData, cacheKey, shouldDecrypt);
            }
            catch (Exception ex)
            {
                throw new CacheException($"Failed to retrieve cache item with key:{cacheKey}", ex);
            }

            try
            {
                item = JsonSerializer.Deserialize<T>(data);
            }
            catch (Exception ex)
            {
                throw new SerializationException($"Failed to deserialize item with {cacheKey}", ex);
            }

            return item;
        }

        public async Task PutAsync(string cacheKey, object item, TimeSpan duration, bool shouldEncrypt = false)
        {
            if (item == null)
                return;

            string data;

            try
            {
                data = JsonSerializer.Serialize(item);
            }
            catch (Exception ex)
            {
                throw new SerializationException($"Failed to serialize cache item with key:{cacheKey}", ex);
            }

            try
            {
                await _database.StringSetAsync(cacheKey, Encrypt(data, cacheKey,shouldEncrypt), duration);
            }
            catch(Exception ex)
            {
                throw new CacheException($"Failed to cache {cacheKey}", ex);
            }
        }

        private string Encrypt(string text, string key, bool shouldEncrypt)
        {
            if (!shouldEncrypt)
            {
                return text;
            }

            return text.Encrypt(key);
        }

        private string Decrypt(string text, string key, bool shouldDecrypt)
        {
            if (!shouldDecrypt)
            {
                return text;
            }

            return text.Decrypt(key);
        }
    }
}
