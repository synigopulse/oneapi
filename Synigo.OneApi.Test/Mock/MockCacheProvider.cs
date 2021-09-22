using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Synigo.OneApi.Common.Extensions;
using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Test.Mock
{
    public class MockCacheProvider : ICacheProvider
    {
        private readonly Dictionary<string, string> _cache;
        private const string _encryptString = "WhiteCrooksInThaSnow";

        public MockCacheProvider()
        {
            _cache = new Dictionary<string, string>();
        }

        public Task ClearAsync()
        {
            _cache.Clear();
            return Task.FromResult(0);
        }

        public Task<T> GetAsync<T>(string cacheKey, bool decrypt = false)
        {
            if (!_cache.ContainsKey(cacheKey))
            {
                return Task.FromResult(default(T));
            }

            var val = _cache[cacheKey];

            if (decrypt)
            {
                val = val.Decrypt(_encryptString);
            }

            return Task.FromResult(val.Deserialize<T>());
        }

        // ignore duration, this is just a mock implementation
        public Task PutAsync(string cacheKey, object item, TimeSpan duration, bool shouldEncrypt = false)
        {
            

            if(item == null)
            {
                return Task.FromResult(0);
            }

            var serialized = item.Serialize();

            if (shouldEncrypt)
            {
                serialized = serialized.Encrypt(_encryptString);
            }

            _cache[cacheKey] = serialized;

            return Task.FromResult(0);
        }
    }
}
