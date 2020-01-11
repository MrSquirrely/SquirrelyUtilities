using System;
using System.Diagnostics;
using NLog;
using NLog.Config;
using NLog.Fluent;
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

        //private static readonly Lazy<Logger> LoggerLazy = new Lazy<Logger>();
        //public static Logger Instance => LoggerLazy.Value;
        //private static NLog.Logger NLogger(string value) => LogManager.GetLogger(value);
        //public LogConfig Config { get; set; }
        //public void LogError(string message) => NLogger(Config.LogName).Error(message);
        //public void LogError(Exception ex, string message) => NLogger(Config.LogName).Error(ex, message);
        //public void LogInfo(string message) => NLogger(Config.LogName).Info(message);

        //public void Dispose() {
        //    LogManager.Shutdown();
        //}

        //        public void LogError(Exception ex) {
        //#if DEBUG
        //            Debug.WriteLine("++++++++++ Start Error ++++++++++");
        //            Debug.WriteLine("");
        //            Debug.WriteLine($"Message: {ex.Message}\n" +
        //                            $"Stack Trace: {ex.StackTrace}\n" +
        //                            $"Source: {ex.Source}\n" +
        //                            $"Target Site: {ex.TargetSite}");
        //            Debug.WriteLine("");
        //            Debug.WriteLine("++++++++++ End Error  +++++++++++");
        //#endif
        //        }
        public void Dispose() => LogManager.Shutdown();
    }
}
