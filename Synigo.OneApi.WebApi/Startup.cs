using Microsoft.Extensions.Configuration;
using Synigo.OneApi.Core.WebApi;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Providers.Extensions;
using Synigo.OneApi.Providers.Products;
using System.Net.Http;

namespace Synigo.OneApi.WebApi
{
    public class Startup : BaseStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
            
        }

        protected override void ConfigureAppSettings(ref OneApiSettings settings)
        {
            // throw new System.NotImplementedException();
        }

        protected override void ConfigureCustomServices(OneApiBuilder builder)
        {
            // throw new System.NotImplementedException();
        }
    }
}