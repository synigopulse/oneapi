using Synigo.OneApi.Interfaces.Model;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Implement this interface to wrap the result of an execution request.
    /// </summary>
    public interface IExecutionResult
    {
        /// <summary>
        /// Get a boolean value, indicated the request was executed succesfully, or not.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Get a reference to the result of the execution. The requestor must not be bothered by which type this
        /// result actually is, but it should just (maybe) serialize and deliver it.
        /// </summary>
        public object Result { get; }

        /// <summary>
        /// Get a reference to the detailed status of the execution context.
        /// </summary>
        public ExecutionStatus Status { get; }
    }
}
