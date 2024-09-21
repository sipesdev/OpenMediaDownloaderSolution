using System.IO;
using System.Text.RegularExpressions;

namespace OpenMediaDownloader
{
    /**
    * <summary>
    * Asks and reads questions pushed to the terminal
    * </summary>
    */
    public class Reader
    {
        public string URL { get; private set; }
        public string Output { get; private set; }
        public bool IsAudio { get; private set; }

        /**
        * <summary>
        * Reads and parses URL
        * </summary>
        */
        public void GetURL()
        {
            Console.WriteLine("\nEnter or paste a URL:");
            var input = Console.ReadLine();
            Logging.ClearConsoleLine();
            Logging.ClearConsoleLine();
            Logging.ClearConsoleLine();
            //Logging.WriteLine($"INPUT: {input}", LogLevel.INFO);

            if(input == null || !input.StartsWith("http")) // Is this an actual URL?
            {
                Logging.WriteLine("Invalid URL", LogLevel.WARN);
                GetURL();
            } else 
            {
                Logging.WriteLine("URL is valid", LogLevel.INFO);
                this.URL = input;
            }
        }

        /**
        * <summary>
        * Queries user on if the download will be a video
        * </summary>
        */
        public void QueryAudio()
        {
            Console.WriteLine("\nDownload video? (Y/n):");
            ConsoleKey input = Console.ReadKey(true).Key;
            Logging.ClearConsoleLine();
            Logging.ClearConsoleLine();
            //Logging.WriteLine($"INPUT: {input}", LogLevel.INFO);

            if(input == ConsoleKey.Y)
            {
                this.IsAudio = false;
                Logging.WriteLine("IsAudio = false", LogLevel.INFO);
            } else if(input == ConsoleKey.N)
            {
                this.IsAudio = true;
                Logging.WriteLine("IsAudio = true", LogLevel.INFO);
            } else 
            {
                QueryAudio();
            }
        }

        /**
        * <summary>
        * Gets output of file
        * </summary>
        */
        public void GetOutput()
        {
            Console.WriteLine("\nEnter output:");
            var input = Console.ReadLine();
            Logging.ClearConsoleLine();
            Logging.ClearConsoleLine();
            Logging.ClearConsoleLine();
            
            if(input == null || input.Contains("."))
            {
                Logging.WriteLine("Invalid file path", LogLevel.WARN);
                GetOutput();
            } else if(!input.Contains(@"/") || !input.Contains(@"\"))
            {
                input = $@"{Reference.GetHomeDirectory}/Downloads/{input}";
            }

            if(DoesExist(input))
            {
                Logging.WriteLine("Invalid file path", LogLevel.WARN);
                GetOutput();
            } else {
                Logging.WriteLine("Valid file path", LogLevel.INFO);
                this.Output = input;
            }
        }

        private bool DoesExist(string path)
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            
            // Gets the file path
            var currentDirectory = Path.GetDirectoryName(path);
            var directoryPath = Path.GetFullPath(currentDirectory); // TODO: Fix

            var files = Directory.GetFiles(directoryPath, fileName + @".*");
            
            if(files.Length > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}