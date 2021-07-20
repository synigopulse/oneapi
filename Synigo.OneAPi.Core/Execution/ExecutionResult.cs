using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Interfaces.Model;

namespace Synigo.OneAPi.Core.Execution
{
    public class ExecutionResult : IExecutionResult
    {
        public bool Success { get; set; }

        public object Result {get;set;}

        public ExecutionStatus Status { get; set; }
    }
}
