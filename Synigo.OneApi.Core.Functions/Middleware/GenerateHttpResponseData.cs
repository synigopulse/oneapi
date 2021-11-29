using System;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Http;

namespace Synigo.OneApi.Core.Functions.Middleware
{
    public interface IGenerateHttpResponseData
    {
        public Task<HttpResponseData> GetResponseData(HttpRequestData data, Exception ex);
    }

    /// <summary>
    /// Simple implementation of <see cref="IGenerateHttpResponseData"/>
    /// </summary>
    public class GenerateHttpResponseData : IGenerateHttpResponseData
    {
        /// <summary>
        /// Creates simple response data with <see cref="System.Net.HttpStatusCode"/> 500 
        /// with exception message as string in body
        /// </summary>
        /// <param name="data">request data provided by <see cref="ExceptionMiddleware"/></param>
        /// <param name="ex">exception form <see cref="ExceptionMiddleware"/></param>
        /// <returns></returns>
        public async Task<HttpResponseData> GetResponseData(HttpRequestData data, Exception ex)
        {
            var response = data.CreateResponse(System.Net.HttpStatusCode.InternalServerError);
            await response.WriteStringAsync(ex.Message);
            return response;
        }
    }
}
