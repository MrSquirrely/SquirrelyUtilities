using System;
using Newtonsoft.Json;
using SquirrelyUtilities.API.Web;

namespace SquirrelyUtilities.API.Updater {
    public class Updater {
        private static readonly string File = $"{Environment.CurrentDirectory}/SquirrelyUtilities.Updater.exe";

        public static bool CheckForUpdate(string url, double version, string fileName) {
            Downloader.Download(url, fileName);
            Update update = JsonConvert.DeserializeObject<Update>(System.IO.File.ReadAllText(fileName));
            return update.Version > version;
        }

        public static void DownloadUpdateFile(string updateFile, string fileName) {
            Update download = JsonConvert.DeserializeObject<Update>(System.IO.File.ReadAllText(updateFile));
            Downloader.Download(download.DownloadUrl, fileName);
        }

        //Todo: Add in update method

    }
}
