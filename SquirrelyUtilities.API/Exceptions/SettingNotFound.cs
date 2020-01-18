using System;
using System.Collections.Generic;
using System.Text;

namespace SquirrelyUtilities.API.Exceptions {
    public class SettingNotFound : Exception {
        public SettingNotFound() {

        }

        public SettingNotFound(string setting) : base($"{setting} could not be found") {

        }
    }
}
