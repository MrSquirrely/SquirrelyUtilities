
using System;
using System.Diagnostics.Contracts;
using NLog;
using NLog.Config;
using NLog.Fluent;
using NLog.Targets;

namespace SquirrelyUtilities.API.Logging {
    public class LogConfig {

        //Todo: Add the ability to define which levels you want
        public string LoggerName { get; set; } = "default!!Please Name Your Logger!!";
        public bool CreateSeparateFile { get; set; } = false;

    }
}
