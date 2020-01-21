using System;
using System.Reflection;

namespace SquirrelyUtilities.API.Exceptions {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class PluginNotFoundException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="PluginNotFoundException"/> class.
        /// </summary>
        public PluginNotFoundException() {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PluginNotFoundException"/> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public PluginNotFoundException(Assembly assembly) : base($"Could not load: {assembly.FullName}") {

        }
    }
}
