using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Text;
using System.Windows.Forms;

using Sharpotify.Controls;
using Sharpotify.Media;

namespace Sharpotify.Frames
{
    public partial class DownloadControl : UserControl, IDisposable
    {
        private bool disposed, next;
        private Queue<DownloadTrackListItem> downloads;
        private List<DownloadTrackListItem> allItems;
        private DownloadTrackListItem currentDownloadItem;
        private Thread th;
        
        public DownloadControl()
        {
            InitializeComponent();

            disposed = false;
            allItems = new List<DownloadTrackListItem>();
            downloads = new Queue<DownloadTrackListItem>();
            next = true;
        }

        protected void StartThread()
        {
            bool createNew = false;

            if (th == null)
                createNew = true;
            else if (th.ThreadState == ThreadState.Stopped)
                createNew = true;

            if (createNew)
            {
                th = new Thread(new ThreadStart(this.Run));
                th.Name = "Sharpotify.Downloader";
                th.IsBackground = true;
                th.Priority = ThreadPriority.Lowest;
            }
            if (th.ThreadState != ThreadState.Running)
                th.Start();
        }

        public void AddTrack(Track track, int index)
        {
            DownloadTrackListItem i = new DownloadTrackListItem();
            i.Track = track;
            i.FileIndex = index;

            allItems.Add(i);
            downloads.Enqueue(i);
            trackList.Items.Add(i);

            if (downloads.Count <= 1 && next)
                StartThread();
        }

        protected void Run()
        {
            if (downloads.Count <= 0 || !next)
                return;
            
            if (disposed)
            {
                return;
            }
            try
            {
                currentDownloadItem = downloads.Dequeue();
                currentDownloadItem.DownloadFinished += new EventHandler<EventArgs>(currentDownloadItem_Downloaded);
                next = false;
                currentDownloadItem.StartDownload();
            }
            catch{}
        }

        void currentDownloadItem_Downloaded(object sender, EventArgs e)
        {
            currentDownloadItem = null;
            next = true;
            if (downloads.Count > 0)
                StartThread();
        }

        public void Save()
        {
            if (downloads.Count > 0 || currentDownloadItem != null)
            {
                string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "download.list");
                StreamWriter writer = new StreamWriter(filename);

                if (currentDownloadItem != null)
                    writer.WriteLine(currentDownloadItem.Track.Id);

                while (downloads.Count > 0)
                    writer.WriteLine(downloads.Dequeue().Id);

                writer.Close();
            }
        }

        public void Load()
        {
            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "download.list");
            if (System.IO.File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                List<string> ids = new List<string>();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        break;
                    if (line.Trim() == string.Empty)
                        break;

                    ids.Add(line);
                }
                reader.Close();
                System.IO.File.Delete(filename);

                if (ids.Count > 0)
                {
                    List<Track> tracks = Facade.Spotify.BrowseTracks(ids);
                    foreach (Track t in tracks)
                    {
                        if (t.Files != null)
                            if (t.Files.Count > 0)
                            {
                                AddTrack(t, t.Files.Count - 1);
                                Facade.CurrentDownloads.Add(t.Id);
                            }
                    }
                }
            }
        }

        public new void Dispose()
        {
            disposed = true;
            Save();
            allItems.Clear();
            downloads.Clear();
            base.Dispose();
        }
    }
}
