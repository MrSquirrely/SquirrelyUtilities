using System;
using NLog;
using NLog.Config;
using NLog.Fluent;
using NLog.Targets;

namespace SquirrelyUtilities.API.Logging {
    public class Logger : IDisposable {

        private static readonly Lazy<Logger> LoggerLazy = new Lazy<Logger>(() => new Logger());
        public static Logger Instance => LoggerLazy.Value;

        private static NLog.Logger NLogger(string loggerName) => LogManager.GetLogger(loggerName);

         private readonly LoggingConfiguration _configuration = new LoggingConfiguration();
         private readonly FileTarget _logFileTarget = new FileTarget("logfile");
         private readonly ConsoleTarget _logConsoleTarget = new ConsoleTarget("logconsole");
         private readonly DebugTarget _logDebugTarget = new DebugTarget("logdebug");

         public static LogConfig LoggerConfig { get; set; } = new LogConfig();

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

        public void LogInfo(string message) => NLogger(LoggerConfig.LoggerName).Info(message);
        public void LogInfo(Exception ex,string message) => NLogger(LoggerConfig.LoggerName).Info(ex, message);
        public void LogError(string message) => NLogger(LoggerConfig.LoggerName).Error(message);
        public void LogError(Exception ex, string message) => NLogger(LoggerConfig.LoggerName).Error(ex, message);
        public void LogDebug(string message) => NLogger(LoggerConfig.LoggerName).Debug(message);
        public void LogDebug(Exception ex, string message) => NLogger(LoggerConfig.LoggerName).Debug(ex, message);
        public void LogFatal( string message) => NLogger(LoggerConfig.LoggerName).Fatal(message);
        public void LogFatal(Exception ex, string message) => NLogger(LoggerConfig.LoggerName).Fatal(ex, message);
        public void LogWarn(string message) => NLogger(LoggerConfig.LoggerName).Warn(message);
        public void LogWarn(Exception ex, string message) => NLogger(LoggerConfig.LoggerName).Warn(ex, message);

        public void Dispose() => LogManager.Shutdown();
    }
}
