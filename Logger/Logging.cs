using System;

namespace Logger
{
    //TODO: What the fuck is this
    /**
     * <summary>
     * Easy way to log software information
     * </summary>
     */
    public class Logging
    {
        /**
         * <summary>
         * Writes a specified value with a formatted console message
         * </summary>
         */
        public static void WriteLine(string message, LogLevel logLevel)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            var output = "";
            
            switch(logLevel)
            {
                case LogLevel.INFO:
                    output = Format.InfoFormat(time) + message;
                    break;
                case LogLevel.WARN:
                    output = Format.WarnFormat(time) + message;
                    break;
                case LogLevel.ERROR:
                    output = Format.ErrorFormat(time) + message;
                    break;
                case LogLevel.FATAL:
                    output = Format.FatalFormat(time) + message;
                    break;
            }
            Console.WriteLine(output);
        }

        /**
         * <summary>
         * Writes a specified value with a formatted console message
         * </summary>
         */
        public static void WriteLine(int message, LogLevel logLevel)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            var output = "";
            
            switch(logLevel)
            {
                case LogLevel.INFO:
                    output = Format.InfoFormat(time) + message;
                    break;
                case LogLevel.WARN:
                    output = Format.WarnFormat(time) + message;
                    break;
                case LogLevel.ERROR:
                    output = Format.ErrorFormat(time) + message;
                    break;
                case LogLevel.FATAL:
                    output = Format.FatalFormat(time) + message;
                    break;
            }
            Console.WriteLine(output);
        }

        /**
         * <summary>
         * Writes a specified value with a formatted console message
         * </summary>
         */
        public static void WriteLine(decimal message, LogLevel logLevel)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            var output = "";
            
            switch(logLevel)
            {
                case LogLevel.INFO:
                    output = Format.InfoFormat(time) + message;
                    break;
                case LogLevel.WARN:
                    output = Format.WarnFormat(time) + message;
                    break;
                case LogLevel.ERROR:
                    output = Format.ErrorFormat(time) + message;
                    break;
                case LogLevel.FATAL:
                    output = Format.FatalFormat(time) + message;
                    break;
            }
            Console.WriteLine(output);
        }

        /**
         * <summary>
         * Writes a specified value with a formatted console message
         * </summary>
         */
        public static void WriteLine(float message, LogLevel logLevel)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            var output = "";
            
            switch(logLevel)
            {
                case LogLevel.INFO:
                    output = Format.InfoFormat(time) + message;
                    break;
                case LogLevel.WARN:
                    output = Format.WarnFormat(time) + message;
                    break;
                case LogLevel.ERROR:
                    output = Format.ErrorFormat(time) + message;
                    break;
                case LogLevel.FATAL:
                    output = Format.FatalFormat(time) + message;
                    break;
            }
            Console.WriteLine(output);
        }

        /**
         * <summary>
         * Writes a specified value with a formatted console message
         * </summary>
         */
        public static void WriteLine(long message, LogLevel logLevel)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            var output = "";
            
            switch(logLevel)
            {
                case LogLevel.INFO:
                    output = Format.InfoFormat(time) + message;
                    break;
                case LogLevel.WARN:
                    output = Format.WarnFormat(time) + message;
                    break;
                case LogLevel.ERROR:
                    output = Format.ErrorFormat(time) + message;
                    break;
                case LogLevel.FATAL:
                    output = Format.FatalFormat(time) + message;
                    break;
            }
            Console.WriteLine(output);
        }

        /**
         * <summary>
         * Writes a specified value with a formatted console message
         * </summary>
         */
        public static void WriteLine(double message, LogLevel logLevel)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            var output = "";
            
            switch(logLevel)
            {
                case LogLevel.INFO:
                    output = Format.InfoFormat(time) + message;
                    break;
                case LogLevel.WARN:
                    output = Format.WarnFormat(time) + message;
                    break;
                case LogLevel.ERROR:
                    output = Format.ErrorFormat(time) + message;
                    break;
                case LogLevel.FATAL:
                    output = Format.FatalFormat(time) + message;
                    break;
            }
            Console.WriteLine(output);
        }

        /**
         * <summary>
         * Writes a specified value with a formatted console message
         * </summary>
         */
        public static void WriteLine(object message, LogLevel logLevel)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            var output = "";
            
            switch(logLevel)
            {
                case LogLevel.INFO:
                    output = Format.InfoFormat(time) + message;
                    break;
                case LogLevel.WARN:
                    output = Format.WarnFormat(time) + message;
                    break;
                case LogLevel.ERROR:
                    output = Format.ErrorFormat(time) + message;
                    break;
                case LogLevel.FATAL:
                    output = Format.FatalFormat(time) + message;
                    break;
            }
            Console.WriteLine(output);
        }

        public static void ClearConsoleLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
