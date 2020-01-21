using System;

namespace SquirrelyUtilities.API.Exceptions {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class SettingNotFound : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingNotFound"/> class.
        /// </summary>
        public SettingNotFound() {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingNotFound"/> class.
        /// </summary>
        /// <param name="setting">The setting.</param>
        public SettingNotFound(string setting) : base($"{setting} could not be found") {

        }
    }
}
