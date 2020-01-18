namespace SquirrelyUtilities.API.Logging {
    public class LogConfig {
        public string LoggerName { get; set; } = "default!!Please Name Your Logger!!";
        public bool CreateSeparateFile { get; set; } = false;
        public bool LogInfo { get; set; } = true;
        public bool LogDebug { get; set; } = true;
        public bool LogWarn { get; set; } = true;
        public bool LogError { get; set; } = true;
        public bool LogFatal { get; set; } = true;
    }
}
