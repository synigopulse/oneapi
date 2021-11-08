using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Interfaces.Model;
using Synigo.OneApi.Model.Exceptions;

namespace Synigo.OneApi.Core.Execution
{
    public class CurrentRequest : ICurrent
    {
        private Dictionary<string, string> _parameters;
        private readonly HttpRequest _request;
        private readonly AuthorizationLevel _authorizationLevel;
        private readonly IEnumerable<IRequestValidationProvider> _requestValidators;

        public CurrentRequest(HttpRequest request, AuthorizationLevel authorizationLevel, IEnumerable<IRequestValidationProvider> requestValidators)
        {
            _request = request;
            _authorizationLevel = authorizationLevel;
            _requestValidators = requestValidators;
        }

        public IPrincipal Principal { get; internal set; }

        public Dictionary<string, string> Parameters => CreateParameters();

        /// <summary>
        /// Lazy creation of params, both headers and QueryString params are processed.
        /// if there's a duplicate key, the key will receive a sequence number.
        /// QueryString params are processed first so they become more important.
        ///
        /// Authorization param is not processed in querystring to prevent easy spoofing of auth header..
        /// </summary>
        /// <returns>
        ///     All headers and qs params in a single dictionary
        /// </returns>
        private Dictionary<string, string> CreateParameters()
        {
            if (_parameters != null)
            {
                return _parameters;
            }

            _parameters = new Dictionary<string, string>();

            foreach (var param in _request.Query)
            {
                int idx = 1;
                var key = param.Key;
                while (_parameters.ContainsKey(key))
                {
                    key = $"{param.Key}{idx}";
                    idx++;
                }

                if ("authorization".Equals(key, StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                _parameters[key] = param.Value.ToString();
            }

            foreach (var header in _request.Headers)
            {
                int idx = 1;
                var key = header.Key;
                while (_parameters.ContainsKey(key))
                {
                    key = $"{header.Key}{idx}";
                    idx++;
                }

                _parameters[key] = header.Value.ToString();
            }

            return _parameters;
        }

        public async Task<T> GetDataAsync<T>()
        {
            try
            {
                return await JsonSerializer.DeserializeAsync<T>(_request.Body);
            }
            catch (Exception ex)
            {
                throw new SerializationException($"Failed to serialize body of {_request.Path}", ex);
            }
        }

        public async Task<ValidationResult> IsAuthorizedAsync(params string[] scopes)
        {
            var validator = _requestValidators.FirstOrDefault(rv => rv.ValidateFor == _authorizationLevel);

            if (validator == null)
            {
                throw new ArgumentException($"No RequestValidator found for authorization level {_authorizationLevel}. is it implemented and added to service collection?");
            }

            return await validator.IsValidRequestAsyc(_parameters, scopes);
        }
    }
}
