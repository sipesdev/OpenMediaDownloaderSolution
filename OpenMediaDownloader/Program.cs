global using System;
global using Logger;

using System.IO;

using OpenMediaDownloader.Wrapper;

namespace OpenMediaDownloader 
{
    /**
    * <summary>
    * Main class
    * </summary>
    */
    public class Program 
    {
        //TODO: Cleanup
        public static Downloader downloader;
        public static Reader reader = new Reader();

        /**
        * <summary>
        * Entry point
        * </summary>
        */
        public static void Main(string[] args)
        {
            Console.ResetColor();
            HandleArguments(args);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Reference.ASCII_ART);
            Console.ResetColor();
            Console.WriteLine("Starting OpenMediaDownloader v" + Reference.GetVersion + "...");

            // Check if required binaries are present
            Logging.WriteLine("Checking for required binaries...", LogLevel.INFO);
            CheckYTDL();
            CheckFFmpeg();

            //Load configurations

            reader.GetURL();
            reader.QueryAudio();
            try
            {
                downloader = new Downloader(reader.URL, reader.IsAudio);
                downloader.StartedEvent += OutputHandler.StartedEvent;
                downloader.InfoEvent += OutputHandler.InfoEvent;
                downloader.ErrorEvent += OutputHandler.ErrorEvent;
                downloader.ProgressEvent += OutputHandler.ProgressEvent;
                downloader.FinishedEvent += OutputHandler.FinishedEvent;
            } catch (Exception e)
            {
                Logging.WriteLine($"Unable to initialize YTDL process: {e.StackTrace}", LogLevel.ERROR);
            }
            reader.GetOutput();

            // Download the video
            try
            {
                downloader.Download(reader.Output);
            } catch (Exception e)
            {
                Logging.WriteLine($"Unable to download media: {e.StackTrace}", LogLevel.ERROR);
            }
        }

        
        private static void HandleArguments(string[] args) 
        {
            // TODO: Better way of doing all of this
            if(args.Length == 0)
            {
                return;
            } else
            {
                for (int i = 0; i < (args.Length + 1); i++)
                {
                    string arg = args[i];

                    if (arg.StartsWith("-"))
                    {
                        switch (arg)
                        {
                            case "-v":
                            case "--version":
                                Console.WriteLine("v" + Reference.GetVersion);
                                Environment.Exit(0);
                                break;

                            default:
                                Console.WriteLine("Unknown command: " + arg + " (Use --help or -h for a list of commands.)");
                                Environment.Exit(127); // Unknown command
                                break;
                        }
                    }
                }
            }
        }

        private static void CheckYTDL()
        {
            if(!File.Exists(Reference.GetYTDL))
            {
                Logging.WriteLine("Could not find YTDL, please reinstall.", LogLevel.FATAL);
                Environment.Exit(1);
            } else 
            {
                Logging.WriteLine("Found YTDL.", LogLevel.INFO);
                return;
            }
        }

        private static void CheckFFmpeg()
        {
            if(!File.Exists(Reference.GetFFmpeg))
            {
                Logging.WriteLine("Could not find FFmpeg, please reinstall.", LogLevel.FATAL);
                Environment.Exit(1);
            } else 
            {
                Logging.WriteLine("Found FFmpeg.", LogLevel.INFO);
                return;
            }
        }
    }
}