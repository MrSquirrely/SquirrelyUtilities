using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using SquirrelyUtilities.API;
using System.Windows;
using System.Windows.Controls;
using HandyControl.Data;
using SquirrelyUtilities.API.Controls;
using SquirrelyUtilities.API.Logging;
using SquirrelyUtilities.API.Updater;
using TabItem = HandyControl.Controls.TabItem;

namespace SquirrelyUtilities {
    public partial class MainWindow {
        private readonly List<string> _pluginsList = new List<string>();
        private readonly Logger _logger;

        public MainWindow() {
            InitializeComponent();

            AppDomain.CurrentDomain.ProcessExit += MainWindow_OnClosed;

            Logger.LoggerConfig = new LogConfig() {
                LoggerName = "SquirrelyUtilitiesLogger",
                CreateSeparateFile = true
            };
            _logger = Logger.Instance;

            Reference.MainWindow = this;
            Reference.UtilitiesTab = UtilitiesTab;

            foreach (string enumerateFile in Directory.EnumerateFiles(Reference.PluginDirectory)) {
                if (Path.GetExtension(enumerateFile).ToLower() == ".dll") {
                    _pluginsList.Add(enumerateFile);
                }
            }

            IEnumerable<IPlugin> plugins = _pluginsList.SelectMany(pluginPath => {
                Assembly pluginAssembly = LoadPlugins(pluginPath);
                return CreatePlugins(pluginAssembly);
            }).ToList();

            foreach (IPlugin plugin in plugins) {
                Reference.MainPageList.Add(new PageHolder(plugin.MainPage, plugin.Name));
                Reference.SettingsPageList.Add(new PageHolder(plugin.SettingsPage, plugin.SettingsName));
            }

            foreach(TabItem tab in Reference.MainPageList.Select(holder =>
               new TabItem() { Content = new Frame() { Content = holder.Content }, Header = holder.PageName })) {
                UtilitiesTab.Items.Add(tab);
            }
            foreach(TabItem tab in Reference.SettingsPageList.Select(holder =>
                new TabItem() { Content = new Frame() { Content = holder.Content }, Header = holder.PageName })) {
                UtilitiesTab.Items.Add(tab);
            }
        }

        private static Assembly LoadPlugins(string pluginPath) {
            pluginPath = pluginPath.Replace('\\', Path.DirectorySeparatorChar);
            PluginLoader loader = new PluginLoader(pluginPath);
            return loader.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginPath)));
        }

        private static IEnumerable<IPlugin> CreatePlugins(Assembly assembly) {
            int count = 0;
            foreach (Type type in assembly.GetTypes()) {
                if (!typeof(IPlugin).IsAssignableFrom(type)) continue;
                if (Activator.CreateInstance(type) is IPlugin result) {
                    count++;
                    yield return result;
                }
                if (count != 0) continue;
                string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
                throw new ApplicationException(
                    $"Can't find any type which implements IPlugin in {assembly} from {assembly.Location}.\n" +
                    $"Available types: {availableTypes}");
            }
        }

        #region Change Skin

        private void ButtonConfig_OnClick(object sender, RoutedEventArgs e) {
            if(Updater.CheckForUpdate("")) {
                Environment.Exit(1);
            }
        }
        //private void ButtonConfig_OnClick(object sender, RoutedEventArgs e) => PopupConfig.IsOpen = true;

            
    private void ButtonSkins_OnClick(object sender, RoutedEventArgs e) {
            if(!(e.OriginalSource is Button button) || !(button.Tag is SkinType tag)) return;
            PopupConfig.IsOpen = false;
            ((App)Application.Current).UpdateSkin(tag);
        }
        #endregion
        
        private void MainWindow_OnClosed(object? sender, EventArgs e) {
            if(Environment.ExitCode == 1) {
             _logger.LogInfo("Closing");
             string file = "C:\\Users\\mrsqu\\source\\repos\\SquirrelyUtilities\\SquirrelyUtilities.Updater\\bin\\Debug\\netcoreapp3.1\\SquirrelyUtilities.Updater.exe";
             string paramaters = "pram 1 a b c d e f g";
             Process.Start(file, paramaters);
            }
            _logger.Dispose();
        }
    }
}
