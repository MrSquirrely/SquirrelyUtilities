using System;
using System.Windows.Controls;

namespace SquirrelyUtilities.API {
    /// <summary>
    /// 
    /// </summary>
    public interface IPlugin {
        /// <summary>
        /// Gets the main page.
        /// </summary>
        /// <value>
        /// The main page.
        /// </value>
        Page MainPage { get; }
        /// <summary>
        /// Gets the settings page.
        /// </summary>
        /// <value>
        /// The settings page.
        /// </value>
        Page SettingsPage { get; }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get;  }
        /// <summary>
        /// Gets the name of the settings.
        /// </summary>
        /// <value>
        /// The name of the settings.
        /// </value>
        string SettingsName { get; }
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        double Version { get; }
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Init();
    }
}
