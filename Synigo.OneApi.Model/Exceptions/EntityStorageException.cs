using System;
namespace Synigo.OneApi.Model.Exceptions
{
    /// <summary>
    /// Exception which should be thrown when anything fails while performing CRUD actions on entities
    /// </summary>
    public class EntityStorageException : Exception
    {
        /// <summary>
        /// Create a new storage exception
        /// </summary>
        /// <param name="message">What happened?</param>
        /// <param name="innerException">What was the underlying exception?</param>
        public EntityStorageException(string message, Exception innerException) : base(message, innerException)
        {

        }

        /// <summary>
        /// Create a new storage exception
        /// </summary>
        /// <param name="message">What happened?</param>
        public EntityStorageException(string message) : base(message)
        {

        }
    }
}
