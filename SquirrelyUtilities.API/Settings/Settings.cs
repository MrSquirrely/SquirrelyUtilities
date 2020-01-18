using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SquirrelyUtilities.API.Exceptions;

namespace SquirrelyUtilities.API.Settings {
    public class Settings {
        private Dictionary<string, object> _settingsDictionary;

        public void Open(string settingsFile) => _settingsDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(settingsFile));
        public void Save(string settingsFile) => File.WriteAllText(settingsFile, JsonConvert.SerializeObject(_settingsDictionary, Formatting.Indented));
        public object GetSetting(string key) => _settingsDictionary.TryGetValue(key, out object value) ? value : throw new SettingNotFound(key);
    }
}
