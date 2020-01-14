using System.Windows.Controls;
using SquirrelyUtilities.API;

namespace TestPlugin {

    public class Class1 : IPlugin {
        public Page MainPage => new Page1();
        public Page SettingsPage => new Page2();
        public string Name => "Test WPF Library";
        public string SettingsName => "Test WPF Library Settings";
        public double Version => 0.1;
        public void Init() {

        }
    }
}
