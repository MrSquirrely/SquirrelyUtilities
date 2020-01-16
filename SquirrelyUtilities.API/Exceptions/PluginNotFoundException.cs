using System;
using System.Reflection;

namespace SquirrelyUtilities.API.Exceptions {
    public class PluginNotFoundException : Exception {
        public PluginNotFoundException() {

        }

        public PluginNotFoundException(Assembly assembly) : base($"Could not load: {assembly.FullName}") {

        }
    }
}
