using System.Threading.Tasks;

namespace Synigo.OneApi.Common.Mappers
{
    public interface IEntityMapperAsync<TIn, TOut>
          where TOut : class where TIn : class
    {
        Task<TOut> MapAsync(TIn source, TOut dest = null);
    }
}
