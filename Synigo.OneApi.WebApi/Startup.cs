using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Synigo.OneApi.Core.WebApi;

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

        protected override void ConfigureSwaggerGen(SwaggerGenOptions options)
        {
            base.ConfigureSwaggerGen(options);
            options.EnableAnnotations();
        }

        protected override void ConfigureJsonSerializerOptions(JsonOptions options)
        {
            base.ConfigureJsonSerializerOptions(options);
        }
    }
}