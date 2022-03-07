using System.Net;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;
using Synigo.OneApi.Core.Functions.Attributes;
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
                if(!GetCustomAttributesOnClassAndMethod<AnonymousAttribute>(context).Any())
                {
                    // Validate token
                    var principal = await _authenthicationProvider.AuthenticateAsync(context);
                }
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

        private List<T> GetCustomAttributesOnClassAndMethod<T>(FunctionContext context)
            where T: Attribute
        {
            // This contains the fully qualified name of the method
            // E.g. IsolatedFunctionAuth.TestFunctions.ScopesAndAppRoles
            var entryPoint = context.FunctionDefinition.EntryPoint;

            var assemblyPath = context.FunctionDefinition.PathToAssembly;
            var assembly = Assembly.LoadFrom(assemblyPath);
            var typeName = entryPoint.Substring(0, entryPoint.LastIndexOf('.'));
            var type = assembly.GetType(typeName);
            var methodName = entryPoint.Substring(entryPoint.LastIndexOf('.') + 1);
            var method = type.GetMethod(methodName);

            var methodAttributes = method.GetCustomAttributes<T>();
            var classAttributes = method.DeclaringType.GetCustomAttributes<T>();
            return methodAttributes.Concat(classAttributes).ToList();
        }
    }
}
