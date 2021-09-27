namespace Synigo.OneApi.Interfaces.Model
{

    /// <summary>
    /// Enumeration indicating what type of authorization there is to be expected
    /// </summary>
    public enum AuthorizationLevel
    {
        /// <summary>
        /// No Authorization
        /// </summary>
        None,
        /// <summary>
        /// Authorization is done by AzureAd Exchange tokens (JWT Bearer token)
        /// </summary>
        AzureAdExchangeToken
    }
}
