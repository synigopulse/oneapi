using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;

namespace Synigo.OneApi.Core.Functions.Middleware
{
    public interface IAuthenthicationProvider
    {
        Task<ClaimsPrincipal> AuthenticateAsync(FunctionContext context);
    }
}
