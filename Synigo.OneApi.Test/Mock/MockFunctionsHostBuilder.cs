using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Test.Mock
{
    public class MockFunctionsHostBuilder : IFunctionsHostBuilder
    {
        private readonly IServiceCollection _serviceCollection;
        private ServiceProvider _serviceProvider;
        public MockFunctionsHostBuilder()
        {
            _serviceCollection = new ServiceCollection();
        }

        public void FinishSetup()
        {
            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        public IExecutionContext ExecutionContext => _serviceProvider.GetRequiredService<IExecutionContext>();

        public IServiceCollection Services => _serviceCollection;
    }
}
