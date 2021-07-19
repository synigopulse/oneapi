namespace Synigo.OneApi.Interfaces.Model
{

    /// <summary>
    /// this enumeration explains if the requested action succeeded, or not. If not it will indicate why
    /// </summary>
    public enum ExecutionStatus
    {
        /// <summary>
        /// The requested action was a success
        /// </summary>
        Success,

        /// <summary>
        /// The requested action failed due to bad input
        /// </summary>
        BadInput,

        /// <summary>
        /// The requested action failed because it was not authorized
        /// </summary>
        Unauthorized,

        /// <summary>
        /// The requested action failed because the requested object was not found
        /// </summary>
        NotFound
    }
}