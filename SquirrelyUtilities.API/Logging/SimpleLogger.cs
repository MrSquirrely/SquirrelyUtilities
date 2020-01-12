using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SquirrelyUtilities.API.Logging {
    public class Logger : IDisposable {
        //Todo: Create some custom exceptions
        //Todo: Add logging things!
        //Add: Debug(String)
        //Add: Debug(Exception)
        //Add: Info(String)
        //Add: Info(Exception)
        //Add: Critical(String)
        //Add: Critical(Exception)

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
             
            _configuration.AddRuleForAllLevels(_logFileTarget);
            _configuration.AddRuleForAllLevels(_logConsoleTarget);
            _configuration.AddRuleForAllLevels(_logDebugTarget);

            LogManager.Configuration = _configuration;
         }

        public void LogInfo(string message) => NLogger(LoggerConfig.LoggerName).Info(message);
        public void LogError(Exception ex, string message) => NLogger(LoggerConfig.LoggerName).Error(ex, message);
        public void Dispose() => LogManager.Shutdown();
    }
}
