using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Synigo.OneApi.Interfaces;
using Synigo.OneAPi.Core.Execution;
using Synigo.OneAPi.Interfaces.Model;

namespace Synigo.OneAPi.Core.Logic
{
    internal class RequestContextBuilder
    {
        public RequestContextBuilder()
        {
        }

        public ICurrent CreateCurrent(HttpRequest request, List<IRequestValidationProvider> validators, AuthorizationLevel authorizationLevel)
        {
            return new CurrentRequest(request, authorizationLevel, validators);
        }
    }
}
