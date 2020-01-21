using System;
using System.Net;

namespace SquirrelyUtilities.API.Web {
    /// <summary>
    /// Used to download files
    /// </summary>
    public class Downloader {
        /// <summary>
        /// Downloads the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="fileName">Name of the file.</param>
        public static void DownloadUpdate(string url, string fileName) {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, $"UpdateTemp/{fileName}");
            webClient.Dispose();
        }
        public static void DownloadPluginInfo(string url, string fileName) {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, $"{Environment.CurrentDirectory}/Plugins/Downloads/Official/{fileName}");
            webClient.Dispose();
        }
    }
}
