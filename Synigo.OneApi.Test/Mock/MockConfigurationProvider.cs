using System.Collections.Generic;
using System.Threading.Tasks;
using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Test.Mock
{
    public class MockConfigurationProvider : IConfigurationProvider
    {
        private readonly Dictionary<string, string> _configuration;

        public MockConfigurationProvider(Dictionary<string,string> configuration)
        {
            _configuration = configuration;
        }

        public Task<string> GetAsync(string key)
        {
            if (_configuration.ContainsKey(key))
            {
                return Task.FromResult(_configuration[key]);
            }

            return Task.FromResult(default(string));
        }

        public void Reset()
        {
            _configuration.Clear();
        }
    }
}
