using System.Collections.Generic;
using System.Threading.Tasks;
using Synigo.OneApi.Interfaces.Model;
using Synigo.OneAPi.Interfaces.Model;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Implement this interface to validate a request based on how you want to validate it
    /// </summary>
    public interface IRequestValidationProvider
    {
        /// <summary>
        /// For what type would you like to validate the request
        /// </summary>
        public AuthorizationLevel ValidateFor { get; }

        /// <summary>
        /// Actually validate the request
        /// </summary>
        /// <param name="parameters">A dictionary of all headers and querystring params</param>
        /// <param name="scopes">Optionally if you want to validate a specific scope, you can implement it</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the request is valid (authorized) or not</returns>
        public Task<ValidationResult> IsValidRequestAsyc(Dictionary<string, string> parameters, params string[] scopes);
    }
}
