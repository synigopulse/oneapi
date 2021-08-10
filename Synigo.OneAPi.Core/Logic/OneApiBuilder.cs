using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Synigo.OneApi.Interfaces;
using Synigo.OneAPi.Core.Execution;

namespace Synigo.OneAPi.Core.Logic
{
    public class OneApiBuilder
    {
        private readonly IServiceCollection _services;
        public OneApiBuilder(IFunctionsHostBuilder functionsHostBuilder)
        {
            _services = functionsHostBuilder.Services;
        }

        public OneApiBuilder AddConfigurationProvider(Func<IServiceProvider, IConfigurationProvider> configurationFunc)
        {
            _services.AddSingleton(configurationFunc);
            return this;
        }

        public OneApiBuilder AddRequestValidationProvider(Func<IServiceProvider, IRequestValidationProvider> configurationFunc)
        {
            _services.AddSingleton(configurationFunc);
            return this;
        }

        public OneApiBuilder AddCacheProvider(Func<IServiceProvider, ICacheProvider> configurationFunc)
        {
            _services.AddSingleton(configurationFunc);
            return this;
        }

        public OneApiBuilder AddExecutionContext()
        {
            // Execution context lives per request so add scoped
            _services.AddScoped((IServiceProvider serviceProvider) =>
            {
                return CreateExecutionContext(serviceProvider);
            });

            return this;
        }

        private IExecutionContext CreateExecutionContext(IServiceProvider serviceProvider)
        {
            return new OneApiExecutionContext(serviceProvider);
        }
    }
}