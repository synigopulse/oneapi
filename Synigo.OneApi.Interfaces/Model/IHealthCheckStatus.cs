using System.Collections.Generic;

namespace Synigo.OneApi.Interfaces.Model
{
    /// <summary>
    /// Implement this interface to return the health status of a particular <see cref="IRequestExecutor"/>
    /// </summary>
    public interface IHealthCheckStatus
    {
        /// <summary>
        /// Get a dictionary with key values of items describing the status in a human readable way
        /// </summary>
        public Dictionary<string,string> CheckInfo { get; }

        /// <summary>
        /// Get the status of the <see cref="IRequestExecutor"/>
        /// </summary>
        public HealtCheckStatus Status { get; }

        /// <summary>
        /// Get an additional message regarding the health of the <see cref="IRequestExecutor"/>
        /// </summary>
        public string Message { get; }
    }
}
