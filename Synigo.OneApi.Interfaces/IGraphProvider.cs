using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace Synigo.OneApi.Interfaces
{
    public interface IGraphProvider
    {
        /// <summary>
        /// Creates a <see cref="GraphServiceClient"/> instance using an authentication provider
        /// containing an access token acquired for client using the specified scopes.
        /// </summary>
        /// <returns>An instance of <see cref="GraphServiceClient"/> containing the authentication provider created
        /// for client.</returns>
        GraphServiceClient GetGraphServiceClientForClient();
        /// <summary>
        /// Creates a <see cref="GraphServiceClient"/> instance using an authentication provider
        /// containing an access token acquired on behalf of another API using the <paramref name="jwtBearerToken"/>
        /// and specified scopes.
        /// </summary>
        /// <param name="jwtBearerToken">The exchange token to use when generating the new access token.</param>
        /// <returns>An instance of <see cref="GraphServiceClient"/> containing the authentication provider created
        /// on behalf of another API.</returns>
        GraphServiceClient GetGraphServiceClientOnBehalfOf(string jwtBearerToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorizationCode"></param>
        /// <returns></returns>
        GraphServiceClient GetGraphServiceClientByAuthorizationCode(string authorizationCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        GraphServiceClient GetGraphServiceClientSilent(IAccount account);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginHint"></param>
        /// <returns></returns>
        GraphServiceClient GetGraphServiceClientSilent(string loginHint);
    }
}
