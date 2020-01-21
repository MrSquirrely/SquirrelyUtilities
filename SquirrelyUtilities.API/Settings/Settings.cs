using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SquirrelyUtilities.API.Exceptions;

namespace SquirrelyUtilities.API.Settings {
    /// <summary>
    /// 
    /// </summary>
    public class Settings {
        private Dictionary<string, object> _settingsDictionary;
        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        public Settings() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        /// <param name="settingsFile">The settings file.</param>
        public Settings(string settingsFile) => Open(settingsFile);
        /// <summary>
        /// Opens the specified settings file.
        /// </summary>
        /// <param name="settingsFile">The settings file.</param>
        public void Open(string settingsFile) => _settingsDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(settingsFile));
        /// <summary>
        /// Saves the specified settings file.
        /// </summary>
        /// <param name="settingsFile">The settings file.</param>
        public void Save(string settingsFile) => File.WriteAllText(settingsFile, JsonConvert.SerializeObject(_settingsDictionary, Formatting.Indented));
        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>A mappable object</returns>
        /// <exception cref="SettingNotFound"></exception>
        public object GetSetting(string key) => _settingsDictionary.TryGetValue(key, out object value) ? value : throw new SettingNotFound(key);
        /// <summary>
        /// Saves the setting.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="SettingNotFound"></exception>
        public void SaveSetting(string key, object value) => _settingsDictionary[key] = _settingsDictionary.TryGetValue(key, out _) ? value : throw new SettingNotFound(key);
    }
}
