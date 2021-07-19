using Synigo.OneApi.Model;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Interface for communicating using SQL
    /// </summary>
    /// <typeparam name="T">The type of the entity, must be a subclass of <see cref="AbstractEntity"/></typeparam>
    public interface ISqlProvider<T> :IBaseEntityProvider<T> where T : AbstractEntity
    {

    }
}
