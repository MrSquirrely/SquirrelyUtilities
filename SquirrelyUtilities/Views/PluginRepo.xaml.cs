using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HandyControl.Data;
using Newtonsoft.Json;
using SquirrelyUtilities.API.Web;
using Path = System.IO.Path;

namespace SquirrelyUtilities.Views {
    /// <summary>
    /// Interaction logic for PluginRepo.xaml
    /// </summary>
    public partial class PluginRepo : UserControl {
        
        public PluginRepo() {
            Downloader.DownloadPluginInfo("https://github.com/MrSquirrely/SU-Official/archive/master.zip", "OfficialPlugins.zip");
            ZipFile.ExtractToDirectory($"{Environment.CurrentDirectory}/Plugins/Downloads/Official/OfficialPlugins.zip",$"{Environment.CurrentDirectory}/Plugins/Downloads/Official/", true);
            
            InitializeComponent();
            foreach (string enumerateFile in Directory.EnumerateFiles($"{Environment.CurrentDirectory}/Plugins/Downloads/Official/")) {
                if (Path.GetExtension(enumerateFile) != ".json") continue;
                PluginInfo pluginInfo = JsonConvert.DeserializeObject<PluginInfo>(File.ReadAllText(enumerateFile));
                PluginPanel.Children.Add(new PluginInfoViewer(pluginInfo.Name, pluginInfo.Description, pluginInfo.DownloadUrl, pluginInfo.Tags));
            }
        }

        private void SearchBar_OnSearchStarted(object? sender, FunctionEventArgs<string> e) {
            Debug.WriteLine(PluginSearchBar.Text);
        }
    }
}
