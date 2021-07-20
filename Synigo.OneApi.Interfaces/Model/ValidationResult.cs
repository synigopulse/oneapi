namespace Synigo.OneApi.Interfaces.Model
{
    /// <summary>
    /// Class to return indicate if validating a request succeeded
    /// and if not, what's wrong with the request.
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Get or set if the request was vaild
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Get or set a message what's wrong, when the request is not valid
        /// </summary>
        public string ValidationMessage { get; set; }
    }
}
