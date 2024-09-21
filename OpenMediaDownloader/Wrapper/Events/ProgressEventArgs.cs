namespace OpenMediaDownloader.Wrapper.Events
{
    /**
    * <summary>
    * Used for progress event with YTDL
    * </summary>
    */
    public class ProgressEventArgs : EventArgs
    {
        public object ProcessObject { get; set; }
        public double Percentage { get; set; }
        public string Speed { get; set; }
        public string Error { get; set; }
        public string Info { get; set; }

        public ProgressEventArgs() : base() { }
    }
}