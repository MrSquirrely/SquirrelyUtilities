using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SquirrelyUtilities.API.Controls;

namespace SquirrelyUtilities.API {
    public static class Reference {

        //public static List<Page> MainPageList = new List<Page>();
        //public static List<Page> SettingsPageList = new List<Page>();
        public static List<PageHolder> MainPageList = new List<PageHolder>();
        public static List<PageHolder> SettingsPageList = new List<PageHolder>();

        public static Window MainWindow;
        public static TabControl UtilitiesTab;

        public static readonly string PluginDirectory = $"{Environment.CurrentDirectory}/Plugins";

    }
}
