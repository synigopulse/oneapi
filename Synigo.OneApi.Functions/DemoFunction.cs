using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Synigo.OneApi.Core.Execution;
using Synigo.OneApi.Interfaces;
using System;

namespace Synigo.OneApi.Functions
{
    public  class DemoFunction : AbstractRequestExecutor
    {
        public DemoFunction(IExecutionContext context, OneApi.Interfaces.Model.AuthorizationLevel authorizationLevel) : base(context, authorizationLevel)
        {
        }

        [FunctionName("DemoFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            var result = await PrepareAndExecuteAsync(req);
            return new OkObjectResult(null);
        }

        public override Task<IExecutionResult> ExecuteAsync(IExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
