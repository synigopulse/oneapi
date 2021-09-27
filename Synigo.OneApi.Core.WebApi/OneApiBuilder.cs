using System;
using Microsoft.Extensions.DependencyInjection;
using Synigo.OneApi.Core.Logic;

namespace Synigo.OneApi.Core.WebApi
{
    public class OneApiBuilder : BaseOneApiBuilder
    {
        public OneApiBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
