using OpenMediaDownloader.Wrapper.Events;

namespace OpenMediaDownloader
{
    /**
    * <summary>
    * Handles output from YTDL
    * </summary>
    */
    public class OutputHandler
    {
        private static ProgressBar progressBar = new ProgressBar();

        /**
        * <summary>
        * Called when YTDL starts
        * </summary>
        */
        public static void StartedEvent(object sender, DownloadEventArgs args)
        {
            Console.CursorVisible = false;
            Console.Write($"Downloading {Program.reader.URL}... ", LogLevel.INFO);
        }

        /**
        * <summary>
        * Called when info is received
        * </summary>
        */
        public static void InfoEvent(object sender, ProgressEventArgs args)
        {
            // Logging.WriteLine(args.Info, LogLevel.INFO);
        }

        /**
        * <summary>
        * Called when an error is received
        * </summary>
        */
        public static void ErrorEvent(object sender, ProgressEventArgs args)
        {
            Logging.WriteLine(args.Error, LogLevel.INFO);
        }

        /**
        * <summary>
        * Called when download progress is received
        * </summary>
        */
        public static void ProgressEvent(object sender, ProgressEventArgs args)
        {
            //Logging.WriteLine(args.Percentage, LogLevel.INFO);adadadadadadadadad
            //Console.Write("Downloading... ");
            progressBar.Report(args.Percentage / 100);
        }

        /**
        * <summary>
        * Called when application is closed
        * </summary>
        */
        public static void FinishedEvent(object sender, DownloadEventArgs args)
        {
            Console.CursorVisible = true;
            // Logging.WriteLine("Completed successfully", LogLevel.INFO);
        }
    }
}