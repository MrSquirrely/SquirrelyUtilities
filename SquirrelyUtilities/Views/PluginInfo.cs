using System;
using System.Collections.Generic;
using System.Text;

namespace SquirrelyUtilities.Views {
    public class PluginInfo {

        public string Name { get; set; }
        public string Description { get; set; }
        public string DownloadUrl { get; set; }
        public IList<string> Tags { get; set; }

    }
}
