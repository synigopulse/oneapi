using System;
namespace Synigo.OneApi.Interfaces
{
    /// <summary>
    /// Interface which can be implemented to write log messages
    /// </summary>
    public interface ILogProvider
    {
        /// <summary>
        /// Write a debug log message
        /// </summary>
        /// <param name="message">The message to write</param>
        /// <param name="args">Optional arguments</param>
        void LogDebug(string message, params object[] args);

        /// <summary>
        /// Write an informational log message
        /// </summary>
        /// <param name="message">The message to write</param>
        /// <param name="args">Optional arguments</param>
        void LogInformation(string message, params object[] args);

        /// <summary>
        /// Write a warning log message
        /// </summary>
        /// <param name="message">The message to write</param>
        /// <param name="args">Optional arguments</param>
        void LogWarning(string message, params object[] args);

        /// <summary>
        /// Write a warning log message with exception
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to write</param>
        /// <param name="args">Optional arguments</param>
        void LogWarning(Exception exception, string message, params object[] args);

        /// <summary>
        /// Write an error log message with exception
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to write</param>
        /// <param name="args">Optional arguments</param>
        void LogError(Exception exception, string message, params object[] args);
    }
}
