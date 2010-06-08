using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Sharpotify.Controls;
using Sharpotify.Media;

namespace Sharpotify.Frames
{
    public partial class TrackControl : UserControl
    {
        private int loadImageTries = 0;
        private Track track;

        public Track Track { get { return track; } set { track = value; LoadTrack(); } }

        public event BrowseTrackHandler BrowseTrack;
        public event BrowseAlbumHandler BrowseAlbum;
        public event BrowseArtistHandler BrowseArtist;

        public TrackControl()
        {
            InitializeComponent();

            trackList.DoubleClick += new EventHandler(trackList_DoubleClick);
            lblAlbum.Click += new EventHandler(lblAlbum_Click);
            lblArtist.Click += new EventHandler(lblArtist_Click);
        }

        void lblArtist_Click(object sender, EventArgs e)
        {
            if (lblArtist.SelectedIndex >= 0)
            {
                if (BrowseArtist != null)
                {
                    Artist a = new Artist();
                    a.Id = lblArtist.Items[lblArtist.SelectedIndex].Value;
                    BrowseArtist(a);
                }
                lblArtist.SelectedIndex = -1;
            }
        }

        void lblAlbum_Click(object sender, EventArgs e)
        {
            if (lblAlbum.SelectedIndex >= 0)
            {
                if (BrowseAlbum != null)
                {
                    Album a = new Album();
                    a.Id = lblAlbum.Items[lblAlbum.SelectedIndex].Value;
                    BrowseAlbum(a);
                }
                lblAlbum.SelectedIndex = -1;
            }
        }

        void trackList_DoubleClick(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex >= 0)
            {
                if (BrowseTrack != null)
                    BrowseTrack(trackList.SelectedItem.Track);
            }
        }

        protected void LoadTrack()
        {
            this.image.Image = null;

            btnPlaylist.Visible = false;
            btnDownload.Visible = false;
            btnPlay.Visible = false;
            
            menuDownload.Items.Clear();
            menuPlayList.Items.Clear();

            lblArtist.Items.Clear();
            lblAlbum.Items.Clear();

            lblTitle.Text = track.Title;
            lblArtist.Items.Add(new WarpLink(track.Artist.Name, track.Artist.Id));
            lblAlbum.Items.Add(new WarpLink(track.Album.Name, track.Album.Id));


            if (Facade.Playlists != null)
            {
                foreach (Playlist p in Facade.Playlists)
                {
                    ToolStripMenuItem i = new ToolStripMenuItem(p.Name);
                    i.Tag = p;
                    i.Click += new EventHandler(PlayList_Click);
                    menuPlayList.Items.Add(i);
                }
                if (Facade.Playlists.Count > 0)
                    btnPlaylist.Visible = true;

            }
            if (Properties.Settings.Default.AllowDownloads)
            {
                if (track.Files != null)
                {
                    int index = 0;
                    foreach (File f in track.Files)
                    {
                        ToolStripMenuItem i = new ToolStripMenuItem(f.Format);
                        i.Tag = index++;
                        i.Click += new EventHandler(Download_Click);
                        menuDownload.Items.Add(i);
                    }
                    if (index > 0)
                    {
                        btnPlay.Visible = true;
                        btnDownload.Visible = true;
                    }
                }
                if (Facade.Library.Contains(track))
                {
                    btnDownload.Visible = false;
                }
                else if (Facade.CurrentDownloads.Contains(track.Id))
                {
                    btnDownload.Visible = false;
                }
            }
            else
                btnDownload.Visible = false;

            try
            {
                txtLyrics.Text = RemoveHTML(Wikia.Lyrics.LyricsSearcher.GetLyrics(track.Artist.Name, track.Title).Lyrics);
            }
            catch { }

            trackList.Reset();
            trackList.Items.Clear();
            if (track.SimilarTracks != null)
                if (track.SimilarTracks.Count > 0)
                    foreach (Track t in track.SimilarTracks)
                        trackList.Items.Add(new TrackListItem(t));


            if (string.IsNullOrEmpty(txtLyrics.Text))
            {
                txtLyrics.Visible = false;
                trackList.Size = new Size(635, 242);
                trackList.Location = new Point(14, 206);
            }
            else
            {
                txtLyrics.Visible = true;
                trackList.Size = new Size(374, 242);
                trackList.Location = new Point(275, 206);
            }

            if (trackList.Items.Count <= 0)
            {
                trackList.Visible = false;
            }
            else
            {
                trackList.Visible = true;
            }
            loadImageTries = 0;
            LoadImage();
        }

        private void Download_Click(object sender, EventArgs e)
        {
            int index = (int)(sender as ToolStripMenuItem).Tag;
            Facade.Download(track, index);
        }
        private void PlayList_Click(object sender, EventArgs e)
        {
            Playlist p = (Playlist)(sender as ToolStripMenuItem).Tag;
            Facade.Spotify.PlaylistAddTrack(p, track);
            Facade.ReloadPlaylists();
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            Facade.PlayTrack(track);
        }

        public string RemoveHTML(string strSource)
        {
            if (string.IsNullOrEmpty(strSource))
                return string.Empty;
            //Here strSource is string containing HTML Code
            return System.Web.HttpUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(strSource, "<(.|\n)*?>", ""));
        }
        private void LoadImage()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.LoadImageRun));
        }

        private void LoadImageRun(object stateInfo)
        {
            try
            {
                if (track != null)
                    if (!string.IsNullOrEmpty(track.Cover))
                    {
                        Image img = Facade.Spotify.Image(track.Cover);
                        image.Invoke(new AnonimousMethod(delegate()
                        {
                            image.Image = img;
                        }));
                    }
            }
            catch
            {
                loadImageTries++;
                if (loadImageTries <= 3)
                    LoadImageRun(stateInfo);
            }
        }

        
    }
}
