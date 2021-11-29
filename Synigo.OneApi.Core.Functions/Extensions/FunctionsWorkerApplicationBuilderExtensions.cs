using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Synigo.OneApi.Core.Functions.Middleware;

namespace Synigo.OneApi.Core.Functions.Extensions
{
    public static class FunctionsWorkerApplicationBuilderExtensions
    {
        /// <summary>
        /// Extension to register exception handeling middlware <see cref="ExceptionHandlelingMiddleware"/>
        /// </summary>
        /// <param name="applicationBuilder"></param>
        /// <returns></returns>
        public static IFunctionsWorkerApplicationBuilder UseOneApiExceptionMiddleware(this IFunctionsWorkerApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionHandlelingMiddleware>();
            return applicationBuilder;
        }
    }
}
