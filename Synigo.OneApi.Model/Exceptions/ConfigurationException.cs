using System;
namespace Synigo.OneApi.Model.Exceptions
{
    /// <summary>
    /// Exception which should be thrown when anything fails while performing a configuration action
    /// </summary>
    public class ConfigurationException : Exception
    {
        /// <summary>
        /// Create a new configuration exception
        /// </summary>
        /// <param name="message">What happened?</param>
        /// <param name="innerException">What was the underlying exception?</param>
        public ConfigurationException(string message, Exception innerException) : base(message, innerException)
        {

        }

        /// <summary>
        /// Create a new configuration exception
        /// </summary>
        /// <param name="message">What happened?</param>
        public ConfigurationException(string message) : base(message)
        {

        }
    }
}
