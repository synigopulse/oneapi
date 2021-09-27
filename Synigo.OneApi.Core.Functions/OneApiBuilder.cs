using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Synigo.OneApi.Core.Logic;

namespace Synigo.OneApi.Core.Functions
{
    public class OneApiBuilder : BaseOneApiBuilder
    {
        public OneApiBuilder(IFunctionsHostBuilder functionsHostBuilder)
        {
            Services = functionsHostBuilder.Services;
        }
    }
}
