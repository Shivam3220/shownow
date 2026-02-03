using ShopNow.Core.Contracts.Interfaces;

namespace ShopNow.Core.Services.Logger
{
    public class LoggerService<T>() : ILoggerService<T>
    {
        public void LogCritical(string message, params object[] args)
        {
            Console.WriteLine("LogCritical: " + string.Format(message, args));
        }

        public void LogCritical(Exception ex, string message, params object[] args)
        {
            Console.WriteLine("LogCritical: " + string.Format(message, args) + " Exception: " + ex.ToString());
        }

        public void LogError(string message, params object[] args)
        {
            Console.WriteLine("LogError: " + string.Format(message, args));
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            Console.WriteLine("LogError: " + string.Format(message, args) + " Exception: " + ex.ToString());
        }

        public void LogInformation(string message, params object[] args)
        {
            Console.WriteLine("LogInformation: " + string.Format(message, args));
        }

        public void LogInformation(Exception ex, string message, params object[] args)
        {
            Console.WriteLine("LogInformation: " + string.Format(message, args) + " Exception: " + ex.ToString());
        }

        public void LogStartingApp()
        {
            Console.WriteLine("Application is starting.");
        }

        public void LogTerminateApp(Exception ex)
        {
            Console.WriteLine("Application is terminating due to an exception: " + ex.ToString());
        }

        public void LogWarning(string message, params object[] args)
        {
            Console.WriteLine("LogWarning: " + string.Format(message, args));
        }

        public void LogWarning(Exception ex, string message, params object[] args)
        {
            Console.WriteLine("LogWarning: " + string.Format(message, args) + " Exception: " + ex.ToString());
        }
    }
}