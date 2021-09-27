using Microsoft.Extensions.Configuration;
using Synigo.OneApi.Core.WebApi;

namespace Synigo.OneApi.WebApi
{
    public class Startup : BaseStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
            
        }

        protected override void ConfigureCustomServices(OneApiBuilder builder)
        {
            //throw new System.NotImplementedException();
        }
    }
}