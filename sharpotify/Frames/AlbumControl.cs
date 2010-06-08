using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Text;
using System.Windows.Forms;

using Sharpotify.Controls;
using Sharpotify.Media;

namespace Sharpotify.Frames
{
    public partial class AlbumControl : UserControl
    {
        private int loadImageTries = 0;
        private Album album;

        public Album Album { get { return album; } set { album = value; LoadAlbum(); } }

        public event BrowseTrackHandler BrowseTrack;
        public event BrowseArtistHandler BrowseArtist;
        public event BrowseAlbumHandler BrowseAlbum;

        public AlbumControl()
        {
            InitializeComponent();

            trackList.DoubleClick += new EventHandler(trackList_DoubleClick);
            lblArtist.Click += new EventHandler(lblArtist_Click);
            lblbSimilar.Click += new EventHandler(lblbSimilar_Click);
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

        void lblbSimilar_Click(object sender, EventArgs e)
        {
            if (lblbSimilar.SelectedIndex >= 0)
            {
                if (BrowseAlbum != null)
                {
                    Album a = new Album();
                    a.Id = lblbSimilar.Items[lblbSimilar.SelectedIndex].Value;
                    BrowseAlbum(a);
                }
                lblArtist.SelectedIndex = -1;
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
        protected void LoadAlbum()
        {
            this.image.Image = null;
            trackList.Reset();
            trackList.Items.Clear();
            lblArtist.Items.Clear();
            lblbSimilar.Items.Clear();

            lblbSimilar.Visible = false;

            downloadTrackToolStripMenuItem.Visible = Properties.Settings.Default.AllowDownloads;

            if (album == null)
                return;

            lblName.Text = album.Name;
            lblReview.Text = RemoveHTML(album.Review);
            
            if (album.Artist != null)
                lblArtist.Items.Add(new WarpLink(album.Artist.Name, album.Artist.Id));
            
            if (album.SimilarAlbums != null)
            {
                if (album.SimilarAlbums.Count > 0)
                { 
                    foreach(Album a in album.SimilarAlbums)
                        lblbSimilar.Items.Add(new WarpLink(a.Name, a.Id));

                    lblbSimilar.Visible = true;
                }
            }

            if (album.Discs != null)
            {
                lblDiscs.Text = "Discs: " + album.Discs.Count;
                for (int i = 0; i < album.Discs.Count; i++)
                {
                    Disc d = album.Discs[i];
                    foreach (Track t in d.Tracks)
                    {
                        //Track aux = album.Tracks.Find(new Predicate<Track>((s) => (s.Id == t.Id)));
                        trackList.Items.Add(new AlbumTrackListItem(t, i + 1));
                    }
                }
            }
            else
            {
                lblDiscs.Text = "";

                if (album.Tracks != null)
                    if (album.Tracks.Count > 0)
                        foreach (Track t in album.Tracks)
                            trackList.Items.Add(new AlbumTrackListItem(t, 1));
            }
            LoadImage();
            btnDownload.Visible = Properties.Settings.Default.AllowDownloads;
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
                if (album != null)
                    if (!string.IsNullOrEmpty(album.Cover))
                    {
                        Image img = Facade.Spotify.Image(album.Cover);
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

        private void btnAddAsPlaylist_Click(object sender, EventArgs e)
        {
            Playlist p = Facade.Spotify.PlaylistCreate(album);
            PlaylistContainer pContainer = Facade.Spotify.PlaylistContainer();
            Facade.Spotify.PlaylistContainerAddPlaylist(pContainer, p);
            Facade.ReloadPlaylists();
            Facade.RefreshMainMenu();
        }

        private void btnDownloads_Click(object sender, EventArgs e)
        {
            foreach (Track t in album.Tracks)
            {
                if (Facade.CurrentDownloads.Contains(t.Id))
                    continue;
                if (Facade.Library.Contains(t))
                    continue;

                if (t.Files != null)
                    if (t.Files.Count > 0)
                        Facade.Download(t, t.Files.Count - 1);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (album.Tracks.Count > 0)
                Facade.PlayListTracks(album.Tracks, false);
        }

        private void browseTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex >= 0)
            {
                if (BrowseTrack != null)
                    BrowseTrack(trackList.SelectedItem.Track);
            }
        }

        private void downloadTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex >= 0)
            {
                Track t = trackList.SelectedItem.Track;
                
                if (Facade.CurrentDownloads.Contains(t.Id))
                    return;
                if (Facade.Library.Contains(t))
                    return;

                if (t.Files != null)
                    if (t.Files.Count > 0)
                        Facade.Download(t, t.Files.Count - 1);
            }
        }

        private void playTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex >= 0)
            {
                Track t = trackList.SelectedItem.Track;
                Facade.PlayTrack(t);
            }
        }
    }
}
