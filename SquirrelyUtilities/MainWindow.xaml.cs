using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Timers;
using SquirrelyUtilities.API;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using HandyControl.Data;
using SquirrelyUtilities.API.Controls;
using SquirrelyUtilities.API.Exceptions;
using SquirrelyUtilities.API.Logging;
using SquirrelyUtilities.API.Updater;
using SquirrelyUtilities.Views;
using Reference = SquirrelyUtilities.API.Reference;
using TabItem = HandyControl.Controls.TabItem;
using Timer = System.Timers.Timer;

namespace SquirrelyUtilities {
    public partial class MainWindow {
        private readonly List<string> _pluginsList = new List<string>();
        private SettingsWindow _settingsWindow;
        private const string UpdateJsonUrl = "https://raw.githubusercontent.com/MrSquirrely/UpdateJsons/master/main.json";
        private const double Version = 0.5;
        private bool _isUpdated;
        private readonly Logger _logger;
        private Timer _timer = new Timer {
            Interval = 30000
        };

        public MainWindow() {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("de");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("de");
            //LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            InitializeComponent();
            NonClientAreaBackground = SystemParameters.WindowGlassBrush;

            AppDomain.CurrentDomain.ProcessExit += MainWindow_OnClosed;
            _timer.Elapsed += UpdateCheck;
            _timer.Start();
            
            Logger.LoggerConfig = new LogConfig() {
                LoggerName = "SquirrelyUtilitiesLogger",
                CreateSeparateFile = true
            };
            _logger = Logger.Instance;
            _logger.LogInfo($"This is version: {Version}");

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
                plugin.Init();
                Reference.MainPageList.Add(new PageHolder(plugin.MainPage));
                Reference.SettingsPageList.Add(new PageHolder(plugin.SettingsPage));
            }

            foreach (TabItem tab in Reference.MainPageList.Select(holder => new TabItem() {Content = new Frame() {Content = holder.Content}, Header = holder.PageName})) {
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
        
        private void ConfigButton_OnClick(object sender, RoutedEventArgs e) {
            _settingsWindow = new SettingsWindow {
                Owner = this
            };
            Effect = new BlurEffect();
            _settingsWindow.ShowDialog();
            Effect = null;
        }

        private void UpdateCheck(object sender, ElapsedEventArgs e) {
            if (!Updater.CheckForUpdate(UpdateJsonUrl, Version, "main.json")) {
                _timer = new Timer {
                    Interval = 30000
                };
                return;
            }
            UpdateBadge.Dispatcher?.Invoke(() => {
                UpdateBadge.Status = BadgeStatus.Processing;
            });
            _isUpdated = true;
        }

        private void MainWindow_OnClosed(object sender, EventArgs e) {
            if (Environment.ExitCode == 1) {
                _logger.LogInfo("Closing");
                string file = $"{Environment.CurrentDirectory}/SquirrelyUtilities.Updater.exe";
                string parameters = $"-zipfile main.update.7z -output {Environment.CurrentDirectory}/";
                Process.Start(file, parameters);
            }
            _logger.Dispose();
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e) {
            if(!_isUpdated) return;
            MessageBoxResult result = HandyControl.Controls.MessageBox.Ask("Do you restart wish to update?", "There is an update!");
            Debug.WriteLine(result);
            if(result != MessageBoxResult.OK) return;
            Updater.DownloadUpdateFile("main.json", "main.update.7z");
            Environment.Exit(1);
        }

        private void BugButton_OnClick(object sender, RoutedEventArgs e) {

        }
    }
}