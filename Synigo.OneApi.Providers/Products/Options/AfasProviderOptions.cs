namespace Synigo.OneApi.Providers.Products.Options
{
    /// <summary>
    /// Contains options used in the Afas provider.
    /// </summary>
    public class AfasProviderOptions
    {
        /// <value>
        /// The Afas authentication header.
        /// Default value: <c>AfasToken</c>
        /// </value>
        public string AuthHeader { get; set; } = "AfasToken";
        /// <value>
        /// The Afas authentication code in plain text which is then automatically encoded in the proper
        /// Afas format.
        /// Default value: <see cref="string.Empty"/>
        /// </value>
        public string AuthToken { get; set; } = string.Empty;
        /// <value>
        /// The name of the HttpClient instance used for the HTTP requests in the provider.
        /// Default value: <c>AfasClient</c>
        /// </value>
        public string HttpClientName { get; set; } = "AfasClient";
        /// <value>
        /// The base address used in the named HttpClient instance.
        /// Default value: <see cref="string.Empty"/>
        /// </value>
        public string BaseAddress { get; set; } = string.Empty;
        
    }
}
