namespace Synigo.OneApi.Common.Mappers
{
    public interface IEntityMapper<TIn, TOut>
       where TOut : class where TIn : class
    {
        TOut Map(TIn source, TOut dest = null);
    }
}
