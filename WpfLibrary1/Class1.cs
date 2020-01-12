using System;
using System.Windows.Controls;
using SquirrelyUtilities.API;
using SquirrelyUtilities.API.Logging;

namespace WpfLibrary1 {

    public class Class1 : IPlugin {
        public Page MainPage => new Page1();
        public Page SettingsPage => new Page2();
        public string Name => "Test WPF Library";
        public string SettingsName => "Test WPF Library Settings";
        public double Version => 0.1;

    }
}
