using Synigo.OneApi.Model;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Interface for communicating with TableStorage
    /// </summary>
    /// <typeparam name="T">The type of the entity, must be a subclass of <see cref="AbstractEntity"/></typeparam>
    public interface ITableStorageProvider<T> where T : AbstractEntity, IBaseEntityProvider<T>
    {

    }
}