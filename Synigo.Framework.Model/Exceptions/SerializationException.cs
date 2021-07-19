using System;
namespace Synigo.OneApi.Model.Exceptions
{
    /// <summary>
    /// Exception which should be thrown when anything fails while serializing / deserializing data data
    /// </summary>
    public class SerializationException : Exception
    {
        /// <summary>
        /// Create a new SerializationException 
        /// </summary>
        /// <param name="message">What happened?</param>
        /// <param name="innerException">What was the underlying exception?</param>
        public SerializationException(string message, Exception innerException) : base(message, innerException)
        {

        }

        /// <summary>
        /// Create a new SerializationException 
        /// </summary>
        /// <param name="message">What happened?</param>
        public SerializationException(string message) : base(message)
        {

        }
    }
}