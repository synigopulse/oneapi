using System;
namespace Synigo.OneApi.Model.Exceptions
{
   /// <summary>
   /// Exception which should be thrown when anything fails while  executing a request
   /// </summary>
    public class RequestExecutionException : Exception
    {
        /// <summary>
        /// Create a new RequestExecutionException 
        /// </summary>
        /// <param name="message">What happened?</param>
        /// <param name="innerException">What was the underlying exception?</param>
        public RequestExecutionException(string message, Exception innerException) : base(message, innerException)
        {

        }

        /// <summary>
        /// Create a new RequestExecutionException 
        /// </summary>
        /// <param name="message">What happened?</param>
        public RequestExecutionException(string message) : base(message)
        {

        }
    }
}
