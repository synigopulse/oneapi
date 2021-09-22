using System;
using System.Diagnostics;
using Synigo.OneApi.Interfaces;

namespace Synigo.OneApi.Test.Mock
{
    public class MockLogProvider : ILogProvider
    {
        public void LogDebug(string message, params object[] args)
        {
            Debug.WriteLine($"DEBUG:{message}, {string.Join(", ", args)}");
        }

        public void LogError(Exception exception, string message, params object[] args)
        {
            Debug.WriteLine($"ERROR:{exception.Message} - {message}, {string.Join(", ", args)}");
        }

        public void LogInformation(string message, params object[] args)
        {
            Debug.WriteLine($"INFO:{message}, {string.Join(", ", args)}");
        }

        public void LogWarning(string message, params object[] args)
        {
            Debug.WriteLine($"WARNING:{message}, {string.Join(", ", args)}");
        }

        public void LogWarning(Exception exception, string message, params object[] args)
        {
            Debug.WriteLine($"WARNING:{exception.Message} - {message}, {string.Join(", ", args)}");
        }
    }
}
