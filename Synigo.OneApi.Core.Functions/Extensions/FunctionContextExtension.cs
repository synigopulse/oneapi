using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Synigo.OneApi.Core.Functions.Extensions
{
    public static class FunctionContextExtension
    {
        /// <summary>
        /// Method returns <see cref="HttpResponseData"/> from <see cref="FunctionContext"/>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static HttpRequestData GetHttpRequestData(this FunctionContext context)
        {
            var keyValuePair = context.Features.SingleOrDefault(f => f.Key.Name == "IFunctionBindingsFeature");
            var functionBindingsFeature = keyValuePair.Value;
            var type = functionBindingsFeature.GetType();
            var inputData = type.GetProperties().Single(p => p.Name == "InputData").GetValue(functionBindingsFeature) as IReadOnlyDictionary<string, object>;
            return inputData?.Values.SingleOrDefault(o => o is HttpRequestData) as HttpRequestData;
        }

        /// <summary>
        /// This method sets InvocationResult of <see cref="FunctionContext"/>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="response"></param>
        public static void InvokeResult(this FunctionContext context, HttpResponseData response)
        {
            var keyValuePair = context.Features.SingleOrDefault(f => f.Key.Name == "IFunctionBindingsFeature");
            var functionBindingsFeature = keyValuePair.Value;
            var type = functionBindingsFeature.GetType();
            var result = type.GetProperties().Single(p => p.Name == "InvocationResult");
            result.SetValue(functionBindingsFeature, response);
        }
    }
}
