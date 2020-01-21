using System;
using System.Diagnostics;
using Newtonsoft.Json;
using SquirrelyUtilities.API.Web;

namespace SquirrelyUtilities.API.Updater {
    /// <summary>
    /// 
    /// </summary>
    public class Updater {
        private static readonly string File = $"{Environment.CurrentDirectory}/SquirrelyUtilities.Updater.exe";
        private static readonly string TempLocation = $"{Environment.CurrentDirectory}/UpdateTemp/";

        /// <summary>
        /// Checks for an update to the plugin.
        /// </summary>
        /// <param name="url">The URL of the update Json file.</param>
        /// <param name="version">The current version of the software running.</param>
        /// <param name="fileName">Name of the update Json file.</param>
        /// <returns></returns>
        public static bool CheckForUpdate(string url, double version, string fileName) {
            Downloader.DownloadUpdate(url, fileName);
            Update update = JsonConvert.DeserializeObject<Update>(System.IO.File.ReadAllText($"UpdateTemp/{fileName}"));
            return update.Version > version;
        }
        /// <summary>
        /// Downloads the update file.
        /// </summary>
        /// <param name="updateFile">The url of update file.</param>
        /// <param name="fileName">Name of the update file.</param>
        public static void DownloadUpdateFile(string updateFile, string fileName) {
            Update download = JsonConvert.DeserializeObject<Update>(System.IO.File.ReadAllText($"UpdateTemp/{updateFile}"));
            Downloader.DownloadUpdate(download.DownloadUrl, fileName);
        }
        /// <summary>
        /// Updates the file.
        /// </summary>
        /// <param name="zipName">Name of the zip.</param>
        public static void UpdateFile(string zipName) {
            string parameters = $"-zipfile {TempLocation}{zipName} -output {Environment.CurrentDirectory}/Plugins";
            Process.Start(File, parameters);
        }

        //Todo: Add in update method

    }
}
