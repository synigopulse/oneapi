using Microsoft.Graph;
using Microsoft.Identity.Client;
using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Providers.Graph
{
    public abstract class AbstractGraphProvider : IGraphProvider
    {
        private readonly IConfidentialClientApplication _confidentialClientApplication;

        public AbstractGraphProvider(IConfidentialClientApplication confidentialClientApplication)
        {
            _confidentialClientApplication = confidentialClientApplication;
        }

        /// <summary>
        /// Creates a <see cref="GraphServiceClient"/> instance using a <see cref="DelegateAuthenticationProvider"/>
        /// containing an access token acquired for client using the specified scopes.
        /// </summary>
        /// <returns>An instance of <see cref="GraphServiceClient"/> containing the authentication provider created
        /// for client.</returns>
        public virtual GraphServiceClient GetGraphServiceClientForClient()
        {
            var authProvider = new DelegateAuthenticationProvider(async (request) =>
            {
                var result = await _confidentialClientApplication.AcquireTokenForClient(Scopes).ExecuteAsync();

                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.AccessToken);
            });

            return new GraphServiceClient(authProvider);
        }

        /// <summary>
        /// Creates a <see cref="GraphServiceClient"/> instance using a <see cref="DelegateAuthenticationProvider"/>
        /// containing an access token acquired on behalf of another API using the <paramref name="jwtBearerToken"/>
        /// and specified scopes.
        /// </summary>
        /// <param name="jwtBearerToken">The exchange token to use when generating the new access token.</param>
        /// <returns>An instance of <see cref="GraphServiceClient"/> containing the authentication provider created
        /// on behalf of another API.</returns>
        public virtual GraphServiceClient GetGraphServiceClientOnBehalfOf(string jwtBearerToken)
        {
            var authProvider = new DelegateAuthenticationProvider(async (request) =>
            {
                var userAssertion = new UserAssertion(jwtBearerToken);
                var result = await _confidentialClientApplication.AcquireTokenOnBehalfOf(Scopes, userAssertion).ExecuteAsync();

                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.AccessToken);
            });

            return new GraphServiceClient(authProvider);
        }

        public virtual GraphServiceClient GetGraphServiceClientByAuthorizationCode(string authorizationCode)
        {
            var authProvider = new DelegateAuthenticationProvider(async (request) =>
            {
                var result = await _confidentialClientApplication.AcquireTokenByAuthorizationCode(Scopes, authorizationCode).ExecuteAsync();

                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.AccessToken);
            });

            return new GraphServiceClient(authProvider);
        }

        public virtual GraphServiceClient GetGraphServiceClientSilent(IAccount account)
        {
            var authProvider = new DelegateAuthenticationProvider(async (request) =>
            {
                var result = await _confidentialClientApplication.AcquireTokenSilent(Scopes, account).ExecuteAsync();

                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.AccessToken);
            });

            return new GraphServiceClient(authProvider);
        }

        public virtual GraphServiceClient GetGraphServiceClientSilent(string loginHint)
        {
            var authProvider = new DelegateAuthenticationProvider(async (request) =>
            {
                var result = await _confidentialClientApplication.AcquireTokenSilent(Scopes, loginHint).ExecuteAsync();

                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.AccessToken);
            });

            return new GraphServiceClient(authProvider);
        }

        /// <summary>
        /// The scopes to use when acquiring tokens.
        /// </summary>
        protected abstract string[] Scopes { get; }
    }
}
