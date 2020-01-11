using System;

namespace SquirrelyUtilities.Updater {
    class Program {
        //FileZip, FileLocation,
        //The file will be downloaded to a temp directory then when being extracted goes into plugins directory
        //
        static void Main(string[] args) {
            foreach (string s in args) {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }
    }
}
