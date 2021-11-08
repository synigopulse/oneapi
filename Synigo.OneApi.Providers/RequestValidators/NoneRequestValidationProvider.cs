using System.Collections.Generic;
using System.Threading.Tasks;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Interfaces.Model;

namespace Synigo.OneApi.Providers.RequestValidators
{
    public class NoneRequestValidationProvider : IRequestValidationProvider
    {
        public AuthorizationLevel ValidateFor => AuthorizationLevel.None;

        public Task<ValidationResult> IsValidRequestAsyc(Dictionary<string, string> parameters, params string[] scopes)
        {
            return Task.FromResult(new ValidationResult
            {
                IsValid = true,
                ValidationMessage = "Request not validated"
            });
        }
    }
}
