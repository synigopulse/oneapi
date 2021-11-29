using System;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;
using Synigo.OneApi.Core.Functions.Extensions;

namespace Synigo.OneApi.Core.Functions.Middleware
{
    /// <summary>
    /// Middleware for exception handling 
    /// This Middleware uses <see cref="ILogger"/> for logging so the consumer can chose implementation of logger
    /// Response data is created by <see cref="IGenerateHttpResponseData"/> implement inteface to modify response or use our base implementation <see cref="GenerateHttpResponseData"/>
    /// </summary>
    public class ExceptionHandlelingMiddleware : IFunctionsWorkerMiddleware
    {
        private readonly ILogger logger;
        private readonly IGenerateHttpResponseData generateHttpResponse;

        public ExceptionHandlelingMiddleware(
            ILogger logger,
            IGenerateHttpResponseData generateHttpResponse)
        {
            this.logger = logger;
            this.generateHttpResponse = generateHttpResponse;
        }

        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, new object[] { ex.StackTrace, ex.InnerException, ex.InnerException?.StackTrace });
                await InvokeResult(ex, context);
                return;
            }
        }

        private async Task InvokeResult(Exception ex, FunctionContext context)
        {
            var request = context.GetHttpRequestData();
            var response = await generateHttpResponse.GetResponseData(request, ex);
            context.InvokeResult(response);
        }
    }
}
