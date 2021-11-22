using System;

namespace Synigo.OneApi.Model.Exceptions
{
    /// <summary>
    /// Exception which should be thrown when anything fails while performing a cache action
    /// </summary>
    public class CacheException : Exception
    {
        /// <summary>
        /// Create a new cache exception
        /// </summary>
        /// <param name="message">What happened?</param>
        /// <param name="innerException">What was the underlying exception?</param>
        public CacheException(string message, Exception innerException) : base(message, innerException)
        {

        }

        /// <summary>
        /// Create a new cache exception
        /// </summary>
        /// <param name="message">What happened?</param>
        public CacheException(string message) : base(message)
        {

        }
    }
}
