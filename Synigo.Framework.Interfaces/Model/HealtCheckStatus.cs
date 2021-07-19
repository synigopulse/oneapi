namespace Synigo.OneApi.Interfaces.Model
{
    /// <summary>
    /// Enumeration indicating the status of a <see cref="IRequestExecutor"/>
    /// </summary>
    public enum HealtCheckStatus
    {
        /// <summary>
        /// The executor is healthy
        /// </summary>
        Healthy,

        /// <summary>
        /// The executor is Unhealthy
        /// </summary>
        Unhealthy,

        /// <summary>
        /// We do not know the health of the executor
        /// </summary>
        Unknown
    }
}
