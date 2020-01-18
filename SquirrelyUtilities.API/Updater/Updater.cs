using System;
using System.Diagnostics;
using Newtonsoft.Json;
using SquirrelyUtilities.API.Web;

namespace SquirrelyUtilities.API.Updater {
    public class Updater {
        private static readonly string File = $"{Environment.CurrentDirectory}/SquirrelyUtilities.Updater.exe";
        private static readonly string TempLocation = $"{Environment.CurrentDirectory}/UpdateTemp/";

        public static bool CheckForUpdate(string url, double version, string fileName) {
            Downloader.Download(url, fileName);
            Update update = JsonConvert.DeserializeObject<Update>(System.IO.File.ReadAllText($"UpdateTemp/{fileName}"));
            return update.Version > version;
        }

        public static void DownloadUpdateFile(string updateFile, string fileName) {
            Update download = JsonConvert.DeserializeObject<Update>(System.IO.File.ReadAllText($"UpdateTemp/{updateFile}"));
            Downloader.Download(download.DownloadUrl, fileName);
        }

        public static void UpdateFile(string zipName) {
            string parameters = $"-zipfile {TempLocation}{zipName} -output {Environment.CurrentDirectory}/Plugins";
            Process.Start(File, parameters);
        }

        //Todo: Add in update method

    }
}
