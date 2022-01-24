using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Azure.Functions.Worker.Http;
using Synigo.OneApi.Core.Functions.Extensions;

namespace Synigo.OneApi.Core.Functions.Middleware
{
    public class AuthenticationMiddleware : IFunctionsWorkerMiddleware
    {
        private readonly IAuthenthicationProvider _authenthicationProvider;

        public AuthenticationMiddleware(
            IAuthenthicationProvider authenthicationProvider
            )
        {
            _authenthicationProvider = authenthicationProvider;
        }

        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            try
            {
                // Validate token
                var principal = await _authenthicationProvider.AuthenticateAsync(context);

                await next(context);
            }
            catch (SecurityTokenException)
            {
                // Token is not valid (expired etc.)
                var req = context.GetHttpRequestData();
                var response = req.CreateResponse(HttpStatusCode.Unauthorized);
                context.InvokeResult(response);
                return;
            }

        }
    }
}
