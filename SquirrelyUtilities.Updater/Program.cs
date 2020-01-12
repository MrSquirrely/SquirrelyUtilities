using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharpCompress.Archives;
using SharpCompress.Common;

namespace SquirrelyUtilities.Updater {
    class Program {
        private static string _fileZip;
        private static string _pluginLocation;

        static void Main(string[] args) {

            List<string> commandList = args.ToList();

            foreach (string command in commandList) {
                switch (command) {
                    case "-zipfile": {
                        int indexOf = commandList.IndexOf(command);
                        indexOf++;
                        _fileZip = commandList[indexOf];
                        break;
                    }
                    case "-output": {
                        int indexOf = commandList.IndexOf(command);
                        indexOf++;
                        _pluginLocation = commandList[indexOf];
                        break;
                    }
                }
            }

            IArchive archive = ArchiveFactory.Open(@$"{_fileZip}");
            foreach (IArchiveEntry archiveEntry in archive.Entries) {
                if (archiveEntry.IsDirectory) continue;
                Console.WriteLine($"Extracting {archiveEntry.Key} to {_pluginLocation}\\{archiveEntry.Key}");
                archiveEntry.WriteToDirectory(@$"{_pluginLocation}", new ExtractionOptions(){ExtractFullPath = true, Overwrite = true});
            }

            Console.WriteLine("Finished! Click any key to close!");
            Console.ReadLine();
            Process.Start(_pluginLocation);
            Environment.Exit(0);
        }
    }
}
