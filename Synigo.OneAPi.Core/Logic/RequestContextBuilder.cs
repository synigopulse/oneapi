using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Core.Execution;
using Synigo.OneApi.Interfaces.Model;

namespace Synigo.OneApi.Core.Logic
{
    public class RequestContextBuilder
    {
        public RequestContextBuilder()
        {
        }

        public ICurrent CreateCurrent(HttpRequest request, IEnumerable<IRequestValidationProvider> validators, AuthorizationLevel authorizationLevel)
        {
            return new CurrentRequest(request, authorizationLevel, validators);
        }
    }
}
