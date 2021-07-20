using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using Synigo.OneApi.Interfaces.Model;
using Synigo.OneApi.Model.Exceptions;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Implement this interface to create logic to handle the current request, be it a HTTP request
    /// or a Queue triggered request.
    /// </summary>
    public interface ICurrent
    {
        /// <summary>
        /// Get a reference to the current user who is executing this request
        /// </summary>
        public IPrincipal Principal { get; }

        /// <summary>
        /// Validate the execution context and check if the executing
        /// user is authorized to perform this action
        /// </summary>
        /// <param name="scopes">When using scopes, you can check one or more scopes</param>
        /// <returns>A result indicating if current request is authorized and if not a message why</returns>
        public Task<ValidationResult> IsAuthorizedAsync(params string[] scopes);

        /// <summary>
        /// Get a reference to the parameters belonging to this request.
        /// Typically this will be a collection of all HTTP headers and QueryString Params
        /// </summary>
        public Dictionary<string, string> Parameters { get; }

        /// <summary>
        /// If this request contains any incoming data. use this method to get it in a typed way
        /// </summary>
        /// <typeparam name="T">The type of object you want to get</typeparam>
        /// <returns>The object or null if empty</returns>
        /// <exception cref="SerializationException">When the data failed to deserialize into T</exception>
        public Task<T> GetDataAsync<T>();
    }
}