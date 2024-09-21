using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

using OpenMediaDownloader.Wrapper.Events;

namespace OpenMediaDownloader.Wrapper
{
    /**
    * <summary>
    * C# wrapper for downloading media with youtube-dl
    * </summary>
    */
    public class Downloader
    {
        public delegate void ProgressEventHandler(object sender, ProgressEventArgs eventHandler);
        public delegate void FinishedDownloadEventHandler(object sender, DownloadEventArgs args);
        public delegate void StartedDownloadEventHandler(object sender, DownloadEventArgs args);
        public delegate void InfoEventHandler(object sender, ProgressEventArgs args);
        public delegate void ErrorEventHandler(object sender, ProgressEventArgs args);

        public event ProgressEventHandler ProgressEvent;
        public event FinishedDownloadEventHandler FinishedEvent;
        public event StartedDownloadEventHandler StartedEvent;
        public event InfoEventHandler InfoEvent;
        public event ErrorEventHandler ErrorEvent;

        private Object ProcessObject { get; set; }
        private Process YTDLProcess { get; set; }
        private string Args { get; set; }

        public bool IsAudio { get; private set; }
        public bool Started { get; private set; }
        public bool Finished { get; private set; }
        public double Percentage { get; private set; }
        public string URL { get; private set; }
        public string Output { get; private set; }
        public string ConsoleLog { get; private set; }

        public Downloader(string url, bool isAudio)
        {
            this.Started = false;
            this.Finished = false;
            this.IsAudio = isAudio;
            this.Percentage = 0;
            this.URL = url;
            
            if(!URL.StartsWith("https://"))
            {
                 throw new Exception("Invalid URL");
            }

            // Create start info
            YTDLProcess = new Process();
            YTDLProcess.StartInfo.UseShellExecute = false;
            YTDLProcess.StartInfo.RedirectStandardOutput = true;
            YTDLProcess.StartInfo.RedirectStandardError = true;
            YTDLProcess.StartInfo.FileName = Reference.GetYTDL;
            YTDLProcess.StartInfo.CreateNoWindow = true;
            YTDLProcess.EnableRaisingEvents = true;
            // YTDLProcess.OutputDataReceived += (object sender, DataReceivedEventArgs args) => Console.WriteLine(args.Data);
            // YTDLProcess.ErrorDataReceived += (object sender, DataReceivedEventArgs args) => Console.WriteLine(args.Data);
            YTDLProcess.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            YTDLProcess.ErrorDataReceived += new DataReceivedEventHandler(ErrorDataReceived);
            YTDLProcess.Exited += ProcessExited;
        }

        /**
        * <summary>
        * Begin download
        * </summary>
        */
        public void Download(string output)
        {
            // Check if file already exists
            if(File.Exists(output))
            {
                throw new Exception($"{output} exists");
            }

            this.Args += @$"--ffmpeg-location ""{Reference.GetFFmpeg}"" ";

            // Add args
            if(IsAudio)
            {
                // TODO: Add more extensions
                this.Args += @$"-f bestaudio --extract-audio --audio-format mp3 {this.URL} -o ""{output}.%(ext)s""";
            } else
            {
                // TODO: Add more extensions
                this.Args += @$"-f bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best {this.URL} -o ""{output}.%(ext)s""";
            }

            YTDLProcess.StartInfo.Arguments = Args;
            YTDLProcess.Start();
            YTDLProcess.BeginOutputReadLine();
            YTDLProcess.BeginErrorReadLine();
            this.OnDownloadStarted(new DownloadEventArgs() {
                ProcessObject = this.ProcessObject
            });
            YTDLProcess.WaitForExit();
            YTDLProcess.Close();
        }

        /**
        * <summary>
        * Adds an argument to be passed to the YTDL process
        * </summary>
        */
        public void AddArgument(string arg)
        {
            this.Args += arg + " ";
        }

        /** 
        * <summary>
        * Handles output from YTDL
        * </summary>
        */
        public void OutputHandler(object sendingProcess, DataReceivedEventArgs args)
        {
            //TODO: This can be better
            if(String.IsNullOrEmpty(args.Data) || Finished)
            {
                return;
            }
            this.ConsoleLog += args.Data;

            if(args.Data.Contains("ERROR"))
            {
                this.OnDownloadError(new ProgressEventArgs() {
                    Error = args.Data,
                    ProcessObject = this.ProcessObject
                });
                return;
            }

            if(!args.Data.Contains("[download]"))
            {
                this.OnDownloadInfo(new ProgressEventArgs() {
                    Info = args.Data,
                    ProcessObject = this.ProcessObject
                });
                return;
            }

            var pattern = new Regex(@"\b\d+([\.,]\d+)?", RegexOptions.None);
            if(!pattern.IsMatch(args.Data))
            {
                return;
            }

            // Fire off the process event
            var percent = Convert.ToDouble(Regex.Match(args.Data, @"\b\d+([\.,]\d+)?").Value, CultureInfo.InvariantCulture);
            this.Percentage = percent;
            this.OnProgress(new ProgressEventArgs() {
                ProcessObject = this.ProcessObject,
                Percentage = percent
            });

            // Check if finished
            if(percent < 100)
            {
                return;
            }

            if(percent == 100 && !Finished)
            {
                OnDownloadFinished(new DownloadEventArgs() {
                    ProcessObject = this.ProcessObject
                });
            }
        }

        /**
        * <summary>
        * Thrown when an error is received from YTDL process
        * </summary>
        */
        public void ErrorDataReceived(object sendingProcess, DataReceivedEventArgs args)
        {
            if(!String.IsNullOrEmpty(args.Data))
            {
                this.OnDownloadError(new ProgressEventArgs() {
                    Error = args.Data,
                    ProcessObject = this.ProcessObject
                });
            }
        }

        protected virtual void OnProgress(ProgressEventArgs args)
        {
            if(ProgressEvent != null)
            {
                ProgressEvent(this, args);
            }
        }

        protected virtual void OnDownloadFinished(DownloadEventArgs args)
        {
            if(!Finished)
            {
                Finished = true;
                FinishedEvent?.Invoke(this, args);
            }
        }

        protected virtual void OnDownloadStarted(DownloadEventArgs args)
        {
            StartedEvent?.Invoke(this, args);
        }

        protected virtual void OnDownloadInfo(ProgressEventArgs args)
        {
            InfoEvent?.Invoke(this, args);
        }

        protected virtual void OnDownloadError(ProgressEventArgs args)
        {
            ErrorEvent?.Invoke(this, args);
        }

        private void ProcessExited(object sender, EventArgs args)
        {
            OnDownloadFinished(new DownloadEventArgs() {
                ProcessObject = this.ProcessObject
            });
        }
    }
}