using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SquirrelyUtilities.API.Controls;

namespace SquirrelyUtilities.API {
    /// <summary>
    /// 
    /// </summary>
    public static class Reference {
        /// <summary>
        /// The main page list
        /// </summary>
        public static List<PageHolder> MainPageList = new List<PageHolder>();
        /// <summary>
        /// The settings page list
        /// </summary>
        public static List<PageHolder> SettingsPageList = new List<PageHolder>();

        /// <summary>
        /// The main window
        /// </summary>
        public static Window MainWindow;
        /// <summary>
        /// The utilities tab
        /// </summary>
        public static TabControl UtilitiesTab;

        /// <summary>
        /// The plugin directory
        /// </summary>
        public static readonly string PluginDirectory = $"{Environment.CurrentDirectory}/Plugins";

    }
}
