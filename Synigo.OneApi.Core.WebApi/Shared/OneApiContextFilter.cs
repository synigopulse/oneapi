using Microsoft.AspNetCore.Mvc.Filters;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Core.Logic;

namespace Synigo.OneApi.Core.WebApi.Shared
{
    public class OneApiContextFilter :  IActionFilter
    {
        private readonly IExecutionContext _context;

        public OneApiContextFilter(IExecutionContext context)
        {
            _context = context;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _context.Current = new RequestContextBuilder().CreateCurrent(context.HttpContext.Request, null, Interfaces.Model.AuthorizationLevel.AzureAdExchangeToken);
        }
    }
}
