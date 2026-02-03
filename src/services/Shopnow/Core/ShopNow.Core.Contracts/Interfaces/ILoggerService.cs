namespace ShopNow.Core.Contracts.Interfaces
{
    public interface ILoggerService<T>
    {
        /// <summary>
        /// Tracks the general flow of the app. May have long-term value.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogInformation(string message, params object[] args);

        /// <summary>
        /// Tracks the general flow of the app. May have long-term value.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogInformation(Exception ex, string message, params object[] args);

        /// <summary>
        /// For abnormal or unexpected events. Typically includes errors or conditions that don't cause the app to fail.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogWarning(string message, params object[] args);

        /// <summary>
        /// For abnormal or unexpected events. Typically includes errors or conditions that don't cause the app to fail.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogWarning(Exception ex, string message, params object[] args);

        /// <summary>
        /// For errors and exceptions that cannot be handled. 
        /// These messages indicate a failure in the current operation or request, not an app-wide failure.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogError(string message, params object[] args);

        /// <summary>
        /// For errors and exceptions that cannot be handled. 
        /// These messages indicate a failure in the current operation or request, not an app-wide failure.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogError(Exception ex, string message, params object[] args);

        /// <summary>
        /// For failures that require immediate attention. Examples: data loss scenarios, out of disk space.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogCritical(string message, params object[] args);

        /// <summary>
        /// For failures that require immediate attention. Examples: data loss scenarios, out of disk space.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogCritical(Exception ex, string message, params object[] args);

        /// <summary>
        /// Log of application start
        /// </summary>
        void LogStartingApp();

        /// <summary>
        /// Log of any application termination due to exception
        /// </summary>
        /// <param name="ex"></param>
        void LogTerminateApp(Exception ex);
    }
}