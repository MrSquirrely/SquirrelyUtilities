namespace SquirrelyUtilities.API.Logging {
    /// <summary>
    /// 
    /// </summary>
    public class LogConfig {
        /// <summary>
        /// Gets or sets the name of the logger.
        /// </summary>
        /// <value>
        /// The name of the logger.
        /// </value>
        public string LoggerName { get; set; } = "default!!Please Name Your Logger!!";
        /// <summary>
        /// Gets or sets a value indicating whether [create separate file].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [create separate file]; otherwise, <c>false</c>.
        /// </value>
        public bool CreateSeparateFile { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [log information].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log information]; otherwise, <c>false</c>.
        /// </value>
        public bool LogInfo { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether [log debug].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log debug]; otherwise, <c>false</c>.
        /// </value>
        public bool LogDebug { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether [log warn].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log warn]; otherwise, <c>false</c>.
        /// </value>
        public bool LogWarn { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether [log error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log error]; otherwise, <c>false</c>.
        /// </value>
        public bool LogError { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether [log fatal].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log fatal]; otherwise, <c>false</c>.
        /// </value>
        public bool LogFatal { get; set; } = true;
    }
}
