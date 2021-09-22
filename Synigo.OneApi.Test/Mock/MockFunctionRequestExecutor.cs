using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synigo.OneApi.Interfaces;
using Synigo.OneAPi.Core.Execution;
using Synigo.OneAPi.Interfaces.Model;

namespace Synigo.OneApi.Test.Mock
{
    public class MockFunctionRequestExecutor : AbstractRequestExecutor
    {
        private readonly Func<object> _testMethod;
        public MockFunctionRequestExecutor(IExecutionContext context, AuthorizationLevel authorizationLevel, Func<object> testMethod) : base(context, authorizationLevel)
        {
            _testMethod = testMethod;
        }

        public async Task<IActionResult> Run(HttpRequest request, params string[] scopes)
        {
            var result = await PrepareAndExecuteAsync(request, scopes);
            return new OkObjectResult(result.Result);
        }

        public override Task<IExecutionResult> ExecuteAsync(IExecutionContext context)
        {
            return Task.FromResult(new ExecutionResult
            {
                Result = _testMethod(),
                Status = Interfaces.Model.ExecutionStatus.Success,
                Success = true
            } as IExecutionResult);
        }
    }
}