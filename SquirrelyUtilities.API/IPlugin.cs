using System.Windows.Controls;

namespace SquirrelyUtilities.API {
    public interface IPlugin {

        Page MainPage { get; }
        Page SettingsPage { get; }
        string Name { get;  }
        string SettingsName { get; }
    }
}
