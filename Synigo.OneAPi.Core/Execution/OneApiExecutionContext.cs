using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Model;

namespace Synigo.OneApi.Core.Execution
{
    public class OneApiExecutionContext: IExecutionContext
    {
        private readonly IServiceProvider _serviceProvider;

        public OneApiExecutionContext(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICurrent Current { get; set; }

        public ICacheProvider CacheProvider => _serviceProvider.GetRequiredService<ICacheProvider>();

        public IConfigurationProvider ConfigurationProvider => _serviceProvider.GetRequiredService<IConfigurationProvider>();

        public ILogProvider LogProvider => _serviceProvider.GetRequiredService<ILogProvider>();

        public IEnumerable<IRequestValidationProvider> Validators => _serviceProvider.GetServices<IRequestValidationProvider>();

        public TEntityProviderType GetEntityProvider<TEntityProviderType, TForType>() where TForType : AbstractEntity
        {
            throw new NotImplementedException();
        }
    }
}
