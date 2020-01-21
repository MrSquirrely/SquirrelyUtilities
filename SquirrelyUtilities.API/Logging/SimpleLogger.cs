using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SquirrelyUtilities.API.Logging {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Logger : IDisposable {

        private static readonly Lazy<Logger> LoggerLazy = new Lazy<Logger>(() => new Logger());
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static Logger Instance => LoggerLazy.Value;

        private static NLog.Logger NLogger(string loggerName) => LogManager.GetLogger(loggerName);

         private readonly LoggingConfiguration _configuration = new LoggingConfiguration();
         private readonly FileTarget _logFileTarget = new FileTarget("logfile");
         private readonly ConsoleTarget _logConsoleTarget = new ConsoleTarget("logconsole");
         private readonly DebugTarget _logDebugTarget = new DebugTarget("logdebug");
        /// <summary>
        /// Gets or sets the logger configuration.
        /// </summary>
        /// <value>
        /// The logger configuration.
        /// </value>
        public static LogConfig LoggerConfig { get; set; } = new LogConfig();
        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger() {
             _logFileTarget.FileName = LoggerConfig.CreateSeparateFile ? $"{LoggerConfig.LoggerName}.log" : "main.log";

            if (LoggerConfig.LogInfo) {
                _configuration.AddRuleForOneLevel(LogLevel.Info, _logFileTarget);
                _configuration.AddRuleForOneLevel(LogLevel.Info, _logConsoleTarget);
                _configuration.AddRuleForOneLevel(LogLevel.Info, _logDebugTarget);
            }

            if (LoggerConfig.LogDebug) {
                _configuration.AddRuleForOneLevel(LogLevel.Debug, _logFileTarget);
                _configuration.AddRuleForOneLevel(LogLevel.Debug, _logConsoleTarget);
                _configuration.AddRuleForOneLevel(LogLevel.Debug, _logDebugTarget);
            }

            if (LoggerConfig.LogError) {
                _configuration.AddRuleForOneLevel(LogLevel.Error, _logFileTarget);
                _configuration.AddRuleForOneLevel(LogLevel.Error, _logConsoleTarget);
                _configuration.AddRuleForOneLevel(LogLevel.Error, _logDebugTarget);
            }

            if (LoggerConfig.LogFatal) {
                _configuration.AddRuleForOneLevel(LogLevel.Fatal, _logFileTarget);
                _configuration.AddRuleForOneLevel(LogLevel.Fatal, _logConsoleTarget);
                _configuration.AddRuleForOneLevel(LogLevel.Fatal, _logDebugTarget);
            }

            if (LoggerConfig.LogWarn) {
                _configuration.AddRuleForOneLevel(LogLevel.Warn, _logFileTarget);
                _configuration.AddRuleForOneLevel(LogLevel.Warn, _logConsoleTarget);
                _configuration.AddRuleForOneLevel(LogLevel.Warn, _logDebugTarget);
            }

            LogManager.Configuration = _configuration;
         }
        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogInfo(string message) => NLogger(LoggerConfig.LoggerName).Info(message);
        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="message">The message.</param>
        public void LogInfo(Exception ex,string message) => NLogger(LoggerConfig.LoggerName).Info(ex, message);
        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogError(string message) => NLogger(LoggerConfig.LoggerName).Error(message);
        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="message">The message.</param>
        public void LogError(Exception ex, string message) => NLogger(LoggerConfig.LoggerName).Error(ex, message);
        /// <summary>
        /// Logs the debug.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogDebug(string message) => NLogger(LoggerConfig.LoggerName).Debug(message);
        /// <summary>
        /// Logs the debug.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="message">The message.</param>
        public void LogDebug(Exception ex, string message) => NLogger(LoggerConfig.LoggerName).Debug(ex, message);
        /// <summary>
        /// Logs the fatal.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogFatal( string message) => NLogger(LoggerConfig.LoggerName).Fatal(message);
        /// <summary>
        /// Logs the fatal.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="message">The message.</param>
        public void LogFatal(Exception ex, string message) => NLogger(LoggerConfig.LoggerName).Fatal(ex, message);
        /// <summary>
        /// Logs the warn.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogWarn(string message) => NLogger(LoggerConfig.LoggerName).Warn(message);
        /// <summary>
        /// Logs the warn.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="message">The message.</param>
        public void LogWarn(Exception ex, string message) => NLogger(LoggerConfig.LoggerName).Warn(ex, message);
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() => LogManager.Shutdown();
    }
}
