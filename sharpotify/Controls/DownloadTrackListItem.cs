using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharpotify.Controls
{
    public class DownloadTrackListItem : TrackListItem
    {
        #region Fields
        private Sharpotify.Media.MusicStream stream;
        private int fileIndex;
        private bool downloaded;
        private int percentDownloaded;
        private string status;
        #endregion
        #region Properties
        public int FileIndex
        {
            get { return fileIndex; }
            set { fileIndex = value; }
        }
        public bool IsDownloaded { get { return downloaded; } }
        public event EventHandler<EventArgs> DownloadFinished;
        #endregion
        #region Factory
        public DownloadTrackListItem(): base()
        {
            downloaded = false;
            percentDownloaded = 0;
            status = "Waiting";
        }
        public DownloadTrackListItem(Sharpotify.Media.Track track) : base(track)
        {
            downloaded = false;
            percentDownloaded = 0;
            status = "Waiting";
        }
        #endregion
        #region Methods
        public void StartDownload()
        {   
            if (Track == null)
                return;
            status = "Downloading";
            stream = Facade.Spotify.GetMusicStream(Track, Track.Files[fileIndex], new TimeSpan(0, 1, 0));
            stream.NewDataAvailable += new EventHandler<EventArgs>(stream_NewDataAvailable);
            stream.AllDataAvailable += new EventHandler<EventArgs>(stream_AllDataAvailable);
        }
        protected void SaveAndConvert()
        {
            status = "Converting";
            if (Parent != null)
                Parent.Invalidate();

            string fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp\\" + Track.Id + ".ogg");
            EnsureDirectories(fileName);
            System.IO.File.WriteAllBytes(fileName, stream.GetBuffer());

            string[] formats = Properties.Settings.Default.DownloadFormat.Split(',');

            if (formats.Contains<string>("ogg"))
            {
                string aux = System.IO.Path.Combine(GetFullPath(Properties.Settings.Default.DownloadFolder), PrepareFileName() + ".ogg");
                if (System.IO.File.Exists(aux))
                    System.IO.File.Delete(aux);
                System.IO.File.Copy(fileName, aux);
                try
                {
                    TagLib.File ogg = TagLib.Ogg.File.Create(aux);
                    ogg.Tag.Album = Track.Album.Name;
                    ogg.Tag.Artists = new string[] { Track.Artist.Name };
                    ogg.Tag.Track = (uint)Track.TrackNumber;
                    ogg.Tag.Year = (uint)Track.Year;
                    ogg.Tag.Title = Track.Title;
                    ogg.Save();
                }
                catch { }
            }

            if (formats.Contains<string>("mp3"))
            {
                fileName = ConvertProcess(fileName);
                try
                {
                    TagLib.File mp3 = TagLib.File.Create(fileName);
                    mp3.Tag.Album = Track.Album.Name;
                    mp3.Tag.Artists = new string[] { Track.Artist.Name };
                    mp3.Tag.Track = (uint)Track.TrackNumber;
                    mp3.Tag.Year = (uint)Track.Year;
                    mp3.Tag.Title = Track.Title;
                    mp3.Save();
                }
                catch { }
            }
            status = "Downloaded";
            Facade.Library.Add(Track, fileName);
            Facade.Downloaded(Track);
            if (Parent != null)
                Parent.Invalidate();
        }
        protected string ConvertProcess(string filename)
        {
            string resultFilename = System.IO.Path.Combine(GetFullPath(Properties.Settings.Default.DownloadFolder), PrepareFileName() + ".mp3");
            string execFilename = GetFullPath(Properties.Settings.Default.DownloadCommand);
            EnsureDirectories(resultFilename);

            if (System.IO.File.Exists(resultFilename))
                System.IO.File.Delete(resultFilename);
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = execFilename;
                p.StartInfo.Arguments = PrepareCommand(filename, resultFilename);
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                p.Start();
                p.WaitForExit();
                System.IO.File.Delete(filename);
            }
            catch (Exception e)
            {
                status = "Error converting";
                Parent.Invalidate();
            }
            return resultFilename;
        }
        protected string GetFullPath(string filename)
        {
            if (filename.StartsWith(".\\"))
                filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename.Substring(2));
            return filename;
        }
        protected string PrepareFileName()
        {
            string aux = Properties.Settings.Default.DownloadMask;

            aux = aux.Replace("%artist%", Track.Artist.Name);
            aux = aux.Replace("%album%", Track.Album.Name);
            aux = aux.Replace("%track%", Track.Title);
            aux = aux.Replace("%number%", Track.TrackNumber.ToString("00"));
            aux = aux.Replace("%year%", Track.Year.ToString());

            return MakeValidFileName(aux);
        }
        protected string PrepareCommand(string source, string result)
        {
            string aux = Properties.Settings.Default.DownloadArguments.Replace("%source%", "\"" + source + "\"");
            aux = aux.Replace("%result%", "\"" + result + "\"");
            return aux;
        }
        private void EnsureDirectories(string fileName)
        {
            System.IO.DirectoryInfo dirInfo = new System.IO.FileInfo(fileName).Directory;
            EnsureDirectories(dirInfo);
        }
        private void EnsureDirectories(System.IO.DirectoryInfo dir)
        {
            if (!dir.Parent.Exists)
            {
                EnsureDirectories(dir.Parent);
                dir.Create();
            }
            else if (!dir.Exists)
                dir.Create();
        }
        private static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]", invalidChars);
            return System.Text.RegularExpressions.Regex.Replace(name, invalidReStr, "_");
        }
        public override void Draw(System.Drawing.Graphics g, int x, int y, int w, int h)
        {
            base.Draw(g, x, y, w, h);
            //Progressbar
            g.DrawRectangle(System.Drawing.Pens.Green, x + w - 105, y + 20, 100, 10);
            g.FillRectangle(System.Drawing.Brushes.Green, x + w - 105, y + 20, percentDownloaded, 10);
            
            //textstatus
            System.Drawing.Font font = new System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            int aux = (int)(g.MeasureString(status, font).Width + 15);
            g.DrawString(status, font, System.Drawing.Brushes.Black, w - aux, y + 35);
            
            string temp; 
            if (Track.Files != null)
                if (Track.Files.Count > fileIndex)
                {
                    temp = Track.Files[fileIndex].Format + Track.Files[fileIndex].Bitrate;
                    aux = (int)(g.MeasureString(temp, font).Width + 15 + aux);
                    g.DrawString(temp, font, System.Drawing.Brushes.Gray, w - aux, y + 35);
                }
        }
        #endregion
        #region Event Handlers
        void stream_AllDataAvailable(object sender, EventArgs e)
        {
            downloaded = true;
            percentDownloaded = 100;
            if (Parent != null)
                Parent.Invalidate();
            SaveAndConvert();
            if (DownloadFinished != null)
                DownloadFinished(this, new EventArgs());
            
            if (Parent != null)
                Parent.Invalidate();
        }

        void stream_NewDataAvailable(object sender, EventArgs e)
        {
            percentDownloaded = (int)(((double)stream.AvailableLength / (double)stream.Length) * 100);
            Parent.Invalidate();
        }
        #endregion
    }
}
