using System;
using Microsoft.Extensions.DependencyInjection;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Core.Execution;

namespace Synigo.OneApi.Core.Logic
{
    public abstract class BaseOneApiBuilder
    {
        public IServiceCollection Services { get; set; }

        public BaseOneApiBuilder AddConfigurationProvider(Func<IServiceProvider, IConfigurationProvider> configurationFunc)
        {
            RegisterSingletonService(configurationFunc);
            return this;
        }

        public BaseOneApiBuilder AddRequestValidationProvider(Func<IServiceProvider, IRequestValidationProvider> configurationFunc)
        {
            RegisterSingletonService(configurationFunc);
            return this;
        }

        public BaseOneApiBuilder AddCacheProvider(Func<IServiceProvider, ICacheProvider> configurationFunc)
        {
            RegisterSingletonService(configurationFunc);
            return this;
        }


        /// <summary>
        /// Transient services are always different; a new instance is provided to every controller and every service.
        /// </summary>
        /// <typeparam name="TService">The Type of service to regiseter</typeparam>
        /// <param name="configurationFunc">The functions which yields an implementation of T</param>
        /// <returns>this</returns>
        public BaseOneApiBuilder RegisterTransientService<TService>(Func<IServiceProvider, TService> configurationFunc) where TService : class
        {
            Services.AddTransient(configurationFunc);
            return this;
        }

        /// <summary>
        /// Scoped services are the same within a request, but different across different requests.
        /// </summary>
        /// <typeparam name="TService">The Type of service to regiseter</typeparam>
        /// <param name="configurationFunc">The functions which yields an implementation of T</param>
        /// <returns>this</returns>
        public BaseOneApiBuilder RegisterScopedService<TService>(Func<IServiceProvider, TService> configurationFunc) where TService : class
        {
            Services.AddScoped(configurationFunc);
            return this;
        }

        /// <summary>
        /// Singleton services are the same for every object and every request.
        /// </summary>
        /// <typeparam name="TService">The Type of service to regiseter</typeparam>
        /// <param name="configurationFunc">The functions which yields an implementation of T</param>
        /// <returns>this</returns>
        public BaseOneApiBuilder RegisterSingletonService<TService>(Func<IServiceProvider, TService> configurationFunc) where TService : class
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