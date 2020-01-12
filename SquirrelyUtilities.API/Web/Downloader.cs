using System.Net;

namespace SquirrelyUtilities.API.Web {
    public class Downloader {
        public static void Download(string url, string fileName) {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, fileName);
            webClient.Dispose();
        }
    }
}
