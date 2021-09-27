using Microsoft.AspNetCore.Mvc;
using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Core.WebApi
{
    public class OneApiController : ControllerBase
    {
        protected IExecutionContext Context { get; private set; }
        public OneApiController(IExecutionContext context)
        {
            Context = context;
        }
    }
}
