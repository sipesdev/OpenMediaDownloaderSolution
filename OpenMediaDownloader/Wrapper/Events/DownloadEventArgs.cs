namespace OpenMediaDownloader.Wrapper.Events
{
    /**
    * <summary>
    * Used for progress download event with YTDL
    * </summary>
    */
    public class DownloadEventArgs : EventArgs
    {
        public object ProcessObject { get; set; }
        public DownloadEventArgs() : base() { }
    }
}