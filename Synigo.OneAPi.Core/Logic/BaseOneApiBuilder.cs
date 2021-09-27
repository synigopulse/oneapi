using System;
using Microsoft.Extensions.DependencyInjection;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Core.Execution;

namespace Synigo.OneApi.Core.Logic
{
    public abstract class BaseOneApiBuilder
    {
        protected IServiceCollection Services;

        public BaseOneApiBuilder AddConfigurationProvider(Func<IServiceProvider, IConfigurationProvider> configurationFunc)
        {
            Services.AddSingleton(configurationFunc);
            return this;
        }

        public BaseOneApiBuilder AddRequestValidationProvider(Func<IServiceProvider, IRequestValidationProvider> configurationFunc)
        {
            Services.AddSingleton(configurationFunc);
            return this;
        }

        public BaseOneApiBuilder AddCacheProvider(Func<IServiceProvider, ICacheProvider> configurationFunc)
        {
            Services.AddSingleton(configurationFunc);
            return this;
        }

        public BaseOneApiBuilder AddExecutionContext()
        {
            // Execution context lives per request so add scoped
            Services.AddScoped((IServiceProvider serviceProvider) =>
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