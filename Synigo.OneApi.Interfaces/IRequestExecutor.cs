using System.Threading.Tasks;
using Synigo.OneApi.Interfaces.Model;
using Synigo.OneApi.Model.Exceptions;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Implement this interface to execute a piece of logic. The <see cref="IExecutionContext"/> Should
    /// provide you with all the tools and context to actually perform the execution of a request.
    /// </summary>
    public interface IRequestExecutor
    {
        /// <summary>
        /// Execute a request.
        /// </summary>
        /// <param name="context">The <see cref="IExecutionContext"/> which should give all the context needed to execute this request.</param>
        /// <returns>An implementation of <see cref="IExecutionResult"/> </returns>
        /// <exception cref="RequestExecutionException">When something unexpected happens</exception>
        public Task<IExecutionResult> ExecuteAsync(IExecutionContext context);

        /// <summary>
        /// Check the health of the implementation of this interface
        /// </summary>
        /// <param name="context">The context needed to check the health</param>
        /// <returns>An implementation of <see cref="IHealthCheckStatus"/> reflecting the health of the implementation of this interface</returns>
        public Task<IHealthCheckStatus> CheckHealthAsync(IExecutionContext context);
    }
}