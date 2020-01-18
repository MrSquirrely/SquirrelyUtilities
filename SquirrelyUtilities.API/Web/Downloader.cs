using System.Net;

namespace SquirrelyUtilities.API.Web {
    public class Downloader {
        internal static void Download(string url, string fileName) {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, $"UpdateTemp/{fileName}");
            webClient.Dispose();
        }
    }
}
