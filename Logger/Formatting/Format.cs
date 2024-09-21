namespace Logger
{
    /**
     * <summary>
     * Defines formatting for logging messages
     * </summary>
     */
    class Format
    {
        /**
         * <summary>
         * [time | INFO]
         * </summary>
         */
        public static string InfoFormat(string time)
        {
            var output = $"[{time} | INFO] ";
            return output;
        }

        /**
         * <summary>
         * [hour:minute:second.millisecond | WARN]
         * </summary>
         */
        public static string WarnFormat(string time)
        {
            var output = $"[{time} | WARN] ";
            return output;
        }

        /**
         * <summary>
         * [hour:minute:second.millisecond | ERROR]
         * </summary>
         */
        public static string ErrorFormat(string time)
        {
            var output = $"[{time} | ERROR] ";
            return output;
        }

        /**
         * <summary>
         * [hour:minute:second.millisecond | FATAL]
         * </summary>
         */
        public static string FatalFormat(string time)
        {
            var output = $"[{time} | FATAL] ";
            return output;
        }
    }
}
