using System.Collections.Generic;
using System.Threading.Tasks;
using Synigo.OneApi.Model;
using Synigo.OneApi.Model.Exceptions;

namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Super interface which should be overriden by interfaces which
    /// are able to perform CRUD actions on any implementation of <see cref="AbstractEntity"/>, e.g. blob or table storage, or SQL
    /// </summary>
    /// <typeparam name="T">The type of the entity</typeparam>
    public interface IBaseEntityProvider<T> where T: AbstractEntity
    {
       
    }
}
