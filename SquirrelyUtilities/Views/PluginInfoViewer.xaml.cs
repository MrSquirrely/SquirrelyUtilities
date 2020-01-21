using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SquirrelyUtilities.Views {
    /// <summary>
    /// Interaction logic for PluginInfoViewer.xaml
    /// </summary>
    public partial class PluginInfoViewer : UserControl {
        private string _pluginDownloadUrl;
        private IList<string> _pluginTags;

        public PluginInfoViewer(string pluginName, string pluginDescription, string pluginDownloadUrl, IList<string> pluginTags) {
            _pluginDownloadUrl = pluginDownloadUrl;
            _pluginTags = pluginTags;
            InitializeComponent();
            PluginNameTextBox.Text = pluginName;
            PluginDescriptionTextBlock.Text = pluginDescription;
        }
    }
}
