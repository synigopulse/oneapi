using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Interfaces.Model;
using Synigo.OneAPi.Core.Logic;
using Synigo.OneAPi.Interfaces.Model;

namespace Synigo.OneAPi.Core.Execution
{
    public abstract class AbstractRequestExecutor : IRequestExecutor
    {
        private readonly AuthorizationLevel _authorizationLevel;
        private readonly IExecutionContext _context;

        public AbstractRequestExecutor(IExecutionContext context, AuthorizationLevel authorizationLevel)
        {
            _context = context;
            _authorizationLevel = authorizationLevel;
        }

        public virtual Task<IHealthCheckStatus> CheckHealthAsync(IExecutionContext context)
        {
            throw new Exception();
        }

        public abstract Task<IExecutionResult> ExecuteAsync(IExecutionContext context);

        protected async Task<IExecutionResult> PrepareAndExecuteAsync(HttpRequest req, params string[] scopes) 
        {
            _context.Current = new RequestContextBuilder().CreateCurrent(req, _context.Validators, _authorizationLevel);

            var validationResult = await _context.Current.IsAuthorizedAsync(scopes);

            if (!validationResult.IsValid)
            {
                return new ExecutionResult
                {
                    Result = validationResult.ValidationMessage,
                    Status = ExecutionStatus.Unauthorized,
                    Success = false
                };
            }

            return await ExecuteAsync(_context);
        }
    }
}