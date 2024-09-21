using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace OpenMediaDownloader
{
    /**
    * <summary>
    * Global variables
    * </summary>
    */
    public class Reference
    {
        /**
        * <summary>
        * Unnecessary ASCII art
        * </summary>
        */
        public static string ASCII_ART { get; } =
        @"________               .___" + "\n" +
        @"\_____  \   _____    __| _/" + "\n" +
        @" /   |   \ /     \  / __ | " + "\n" +
        @"/    |    \  Y Y  \/ /_/ | " + "\n" +
        @"\_______  /__|_|  /\____ | " + "\n" +
        @"        \/      \/      \/ ";

        /**
        * <summary>
        * Returns version number
        * </summary>
        */
        public static string GetVersion
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyInformationalVersionAttribute)attributes[0]).InformationalVersion;
            }
        }

        /**
        * <summary>
        * Returns the current working directory
        * </summary>
        */
        public static string GetCurrentWorkingDirectory
        {
            get
            {
                try
                {
                    string directory = Directory.GetCurrentDirectory();
                    return directory;
                }
                catch (Exception e)
                {
                    Logging.WriteLine($"Could not get current working directory: {e.StackTrace}", LogLevel.ERROR);
                    return "";
                }
            }
        }

        public static string GetPhysicalDirectory
        {
            get
            {
                try
                {
                    string directory = AppDomain.CurrentDomain.BaseDirectory;
                    return directory;
                }
                catch (Exception e)
                {
                    Logging.WriteLine($"Could not get base directory: {e.StackTrace}", LogLevel.ERROR);
                    return "";
                }
            }
        }

        public static string GetHomeDirectory
        {
            get
            {
                try
                {
                    // TODO: Might not work on other OSes
                    string directory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    return directory;
                }
                catch (Exception e)
                {
                    Logging.WriteLine($"Could not get home directory: {e.StackTrace}", LogLevel.ERROR);
                    return "";
                }
            }
        }

        /**
        * <summary>
        * Return YTDL path
        * </summary>
        */
        public static string GetYTDL
        {
            get
            {
                var path = @$"{GetPhysicalDirectory}lib/yt-dlp";
                if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    path += ".exe";
                }
                return path;
            }
        }

        /**
        * <summary>
        * Return FFmpeg path
        * </summary>
        */
        public static string GetFFmpeg
        {
            get
            {
                var path = @$"{GetPhysicalDirectory}lib/ffmpeg";
                if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    path += ".exe";
                }
                return path;
            }
        }
    }
}